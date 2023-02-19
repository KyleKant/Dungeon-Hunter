using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IItemParent
{
  private const int LEFT_MOUSE = 0;
  private const int RIGHT_MOUSE = 1;
  private const int MIDDLE_MOUSE = 2;

  private const string EQUIPMENT_OBJECT_DROP_POINT = "EquipmentObjectDropPoint";
  public const string EQUIPMENT_OBJECT_HOLD_POINT = "EquipmentObjectHoldPoint";
  public static Player Instance { get; private set; }
  public event EventHandler<OnSelectedObjectChangedEventArgs> OnSelectedObjectChanged;
  public class OnSelectedObjectChangedEventArgs : EventArgs
  {
    public BaseStorage selectedObject;
  }
  [SerializeField] private GameInput gameInput;
  [SerializeField] private float runSpeed = 7f;
  [SerializeField] private float walkSpeed = 2f;
  [SerializeField] private LayerMask baseStorageLayerMask;
  [SerializeField] private Transform equipmentObjectHoldPoint;
  [SerializeField] private Transform equipmentObjectDropPoint;
  private BaseStorage selectedObject;
  private ItemController itemObject;
  public List<ItemController> itemObjectList = new List<ItemController>();
  private FloorObject floorObject;
  private bool isRunning;
  private bool isWalking;
  private bool isIdle;
  private bool isNormalAttack01;
  private bool isNormalAttack02;
  private int pressedNumlockCounter = 0;
  private int clickLeftMouseCounter = 0;
  private Vector3 lastInteractDir;
  private List<Transform> itemObjectDropList = new List<Transform>();

  private void Awake()
  {
    if (Instance != null)
    {
      Debug.LogError("There is more than one Player instance.");
    }
    Instance = this;
  }
  private void Start()
  {
    gameInput.OnInteractAction += GameInput_OnInteractAction;
  }

  private void GameInput_OnInteractAction(object sender, System.EventArgs e)
  {
    if (selectedObject != null)
    {
      selectedObject.Interact(this);
      // Debug.Log("GameInput_OnInteractAction");

    }
    else
    {
      HandleDropEquipment();
    }
  }
  private void Update()
  {
    HandleMovement();
    HandleInteractions();
  }

  private void HandleDropEquipment()
  {
    if (!HasSelectedObject())
    {
      if (itemObjectList.Count != 0)
      {
        ItemController itemObjectFirstDrop = itemObjectList[0];
        itemObjectList.Remove(itemObjectFirstDrop);
        floorObject = GameObject.FindObjectOfType<FloorObject>();
        itemObjectFirstDrop.transform.SetParent(floorObject.transform.Find(EQUIPMENT_OBJECT_DROP_POINT));
        itemObjectFirstDrop.transform.position = equipmentObjectDropPoint.position;
      }
      if (itemObjectList.Count == 0)
      {
        ClearItemObject();
      }
    }
    else
    {
      // There is something selected
    }
  }

  private void HandleInteractions()
  {
    float interactDistance = 2f;
    Vector2 inputVector = gameInput.GetMovementVectorNormalized();
    Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
    if (moveDir != Vector3.zero)
    {
      lastInteractDir = moveDir;
    }
    if (Physics.Raycast(transform.position, lastInteractDir, out RaycastHit raycastHit, interactDistance, baseStorageLayerMask))
    {
      if (raycastHit.transform.TryGetComponent(out BaseStorage baseStorage))
      {
        // Has Base Storage
        if (baseStorage != selectedObject)
        {
          SetSelectedObject(baseStorage);
        }
      }
      else
      {
        SetSelectedObject(null);
      }
    }
    else
    {
      SetSelectedObject(null);
    }
    // Debug.Log(selectedObject);
  }
  private void HandleMovement()
  {
    Vector2 inputVector = gameInput.GetMovementVectorNormalized();
    Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

    // Set isIdle flag
    if (moveDir == Vector3.zero)
    {
      isIdle = true;
      isWalking = false;
      isRunning = false;
    }
    else
    {
      isIdle = false;
    }

    // Walking flag
    if (Input.GetKeyUp(KeyCode.Numlock))
    {
      pressedNumlockCounter += 1;
    }
    if (pressedNumlockCounter > 1)
    {
      pressedNumlockCounter = 0;
    }
    if (isIdle == false)
    {
      switch (pressedNumlockCounter)
      {
        case 0:
          isWalking = false;
          isRunning = true;
          break;
        case 1:
          isWalking = true;
          isRunning = false;
          break;
        default:
          isIdle = true;
          break;
      }
    }
    // Set isRunning flag
    // isRunning = moveDir != Vector3.zero;
    // Collision detect
    float playerRadius = 0.7f;
    float playerHeight = 0.2f;
    float runDistance = runSpeed * Time.deltaTime;
    float walkDistance = walkSpeed * Time.deltaTime;
    bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, runDistance);
    // Debug.Log("canMove:" + canMove);
    if (!canMove)
    {
      // Cannot move towards moveDir

      // Attempt to move along the X axis
      Vector3 moveDirX = new Vector3(moveDir.x, 0f, 0f).normalized;
      canMove = moveDir.x != 0 && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, runDistance);
      if (canMove)
      {
        moveDir = moveDirX;
      }
      else
      {
        // Cannot move along the X axis
        // Attempt to move along the Z axis
        Vector3 moveDirZ = new Vector3(0f, 0f, moveDir.z).normalized;
        canMove = moveDir.z != 0 && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, runDistance);
        if (canMove)
        {
          moveDir = moveDirZ;
        }
        else
        {
          // Cannot move in any direction
        }
      }

    }
    if (canMove)
    {
      if (isRunning == true)
      {
        transform.position += moveDir * runDistance;
      }
      else if (isWalking == true)
      {
        transform.position += moveDir * walkDistance;
      }
    }

    float rotationSpeed = 10f;
    // rotate player
    transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotationSpeed);
    // Debug.Log(isRunning);

    // Event click to player attack
    if (Input.GetMouseButtonUp(LEFT_MOUSE))
    {
      clickLeftMouseCounter += 1;
    }
    if (clickLeftMouseCounter > 2)
    {
      clickLeftMouseCounter = 0;
    }
    switch (clickLeftMouseCounter)
    {
      case 1:
        isNormalAttack01 = true;
        isNormalAttack02 = false;
        isIdle = false;
        break;
      case 2:
        isNormalAttack01 = false;
        isNormalAttack02 = true;
        isIdle = false;
        break;
      default:
        // isIdle = true;
        break;
    }
    if (isIdle == true || isWalking == true || isRunning == true)
    {
      isNormalAttack01 = false;
      isNormalAttack02 = false;
      // Debug.Log("Here");
    }
    // Debug.Log("is normal attack 01:" + isNormalAttack01);
    // Debug.Log("is normal attack 02:" + isNormalAttack02);
  }
  public bool IsIdle()
  {
    return isIdle;
  }
  public bool IsRunning()
  {
    return isRunning;
  }
  public bool IsWalking()
  {
    return isWalking;
  }
  public bool IsNormalAttack01()
  {
    return isNormalAttack01;
  }
  public bool IsNormalAttack02()
  {
    return isNormalAttack02;
  }

  private void SetSelectedObject(BaseStorage selectedObject)
  {
    this.selectedObject = selectedObject;
    OnSelectedObjectChanged?.Invoke(this, new OnSelectedObjectChangedEventArgs
    {
      selectedObject = selectedObject
    });
  }

  public Transform GetItemObjectFollowTransform()
  {
    return equipmentObjectHoldPoint;
  }
  public void SetItemObject(ItemController itemObject)
  {
    this.itemObject = itemObject;
    itemObjectList.Add(itemObject);
  }
  public ItemController GetItemObject(ItemController itemObject)
  {
    return itemObject;
  }
  public void ClearItemObject()
  {
    if (itemObjectList.Count == 0)
    {
      itemObject = null;
    }
  }
  public bool HasItemObject()
  {
    return itemObject != null;
  }
  public bool HasSelectedObject()
  {
    return selectedObject != null;
  }
}
