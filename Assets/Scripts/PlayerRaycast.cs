using System.Collections;
using System.Collections.Generic;
using uMyGUI;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRaycast : MonoBehaviour
{

    public Camera FPSCam;
    public GameObject HandPanel;

    public bool computerFirst = true;
    public bool excavatorFirst = true;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPSCam.transform.position, FPSCam.transform.forward, out hit, 2))
        {
            string name = hit.collider.name;
            if (name.StartsWith("door1")) // button
            {
                HandPanel.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //if (DoorsControl.Instance.locked[0])
                    //{
                    //    NotificationText.Instance.AddNotification("<Locked>");
                    //}
                    //else
                    //{
                    //    DoorsControl.Instance.OpenDoor(0);
                    //}
                    if (InventoryManager.Instance.HasItem(0))
                    {
                        DoorsControl.Instance.OpenDoor(0);
                    }
                    else
                    {
                        NotificationText.Instance.AddNotification("Need <Red Keycard>");
                    }
                }
            }
            else if (name.StartsWith("door2")) // button
            {
                HandPanel.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //if (DoorsControl.Instance.locked[1])
                    //{
                    //    NotificationText.Instance.AddNotification("<Locked>");
                    //}
                    //else
                    //{
                    //    DoorsControl.Instance.OpenDoor(1);
                    //}
                    if (InventoryManager.Instance.HasItem(1))
                    {
                        DoorsControl.Instance.OpenDoor(1);
                    }
                    else
                    {
                        NotificationText.Instance.AddNotification("Need <Green Keycard>");
                    }
                }
            }
            else if (name.StartsWith("computer1"))
            {
                HandPanel.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (computerFirst)
                    {
                        GameManager.Instance.FreezPlayer(true);
                        GameManager.Instance.Pause();
                        ((uMyGUI_PopupText)uMyGUI_PopupManager.Instance.ShowPopup("computer")).SetText("Computer", "<ข้อความระบุว่า ให้รีบออกไปจากที่นี่>\n<รีบไปที่ยานอวกาศ!!>").ShowButton("close", () =>
                        {
                            DoorsControl.Instance.locked[0] = false;
                            //DoorsControl.Instance.locked[1] = false;
                            GameManager.Instance.FreezPlayer(false);
                            GameManager.Instance.Unpause();
                            InventoryManager.Instance.AddItem(0);
                            NotificationText.Instance.AddNotification("<Red Keycard> Added!!!");
                            computerFirst = false;
                        });
                    }
                    else
                    {
                        GameManager.Instance.FreezPlayer(true);
                        GameManager.Instance.Pause();
                        ((uMyGUI_PopupText)uMyGUI_PopupManager.Instance.ShowPopup("craft1")).SetText("Computer1", "<craft calculate and upgrade excavator>").ShowButton("craft", () =>
                          {
                             // craft control chip
                             // craft navigator
                             ((uMyGUI_PopupText)uMyGUI_PopupManager.Instance.ShowPopup("craft1sub")).ShowButton("controlchip", () =>
                              {
                                  ((uMyGUI_PopupDragdrap)uMyGUI_PopupManager.Instance.ShowPopup("dragdrop")).ShowDragdropPanel("craft_controlchip").ShowButton("close", () =>
                                  {
                                      GameManager.Instance.FreezPlayer(false);
                                      GameManager.Instance.Unpause();
                                  });
                              }).ShowButton("navigator", () =>
                              {
                                  ((uMyGUI_PopupDragdrap)uMyGUI_PopupManager.Instance.ShowPopup("dragdrop")).ShowDragdropPanel("craft_navigator").ShowButton("close", () =>
                                  {
                                      GameManager.Instance.FreezPlayer(false);
                                      GameManager.Instance.Unpause();
                                  });
                              }).ShowButton("close", () =>
                              {
                                  GameManager.Instance.FreezPlayer(false);
                                  GameManager.Instance.Unpause();
                              });

                          }).ShowButton("excavator", () =>
                          {
                              uMyGUI_PopupButtons p = ((uMyGUI_PopupText)uMyGUI_PopupManager.Instance.ShowPopup("popup")).SetText("Are you sure?", "Upgrade Excavator\nCopper -100").ShowButton("no", () =>
                              {
                                  GameManager.Instance.FreezPlayer(false);
                                  GameManager.Instance.Unpause();
                              });
                              if(GameManager.Instance.Copper >= 100)
                              {
                                  p.ShowButton("yes", () =>
                                   {
                                       GameManager.Instance.RemoveCopper(100);
                                       GameManager.Instance.UpgradeExcavator(0);
                                       GameManager.Instance.UpgradeExcavator(1);
                                       NotificationText.Instance.AddNotification("Remove 100 Copper");
                                       NotificationText.Instance.AddNotification("Excavator Upgraded!!!");
                                       GameManager.Instance.FreezPlayer(false);
                                       GameManager.Instance.Unpause();
                                   });
                              }
                          }).ShowButton("close", () =>
                          {
                              GameManager.Instance.FreezPlayer(false);
                              GameManager.Instance.Unpause();
                          });
                    }
                }
            }
            else if (name.StartsWith("computer2"))
            {
                HandPanel.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GameManager.Instance.FreezPlayer(true);
                    GameManager.Instance.Pause();
                    ((uMyGUI_PopupText)uMyGUI_PopupManager.Instance.ShowPopup("craft1")).SetText("computer2", "<craft physics and weapon>").ShowButton("craft", () =>
                     {
                        // craft control chip
                        // craft navigator
                        ((uMyGUI_PopupText)uMyGUI_PopupManager.Instance.ShowPopup("craft1sub")).ShowButton("engines", () =>
                    {
                             ((uMyGUI_PopupDragdrap)uMyGUI_PopupManager.Instance.ShowPopup("dragdrop")).ShowDragdropPanel("craft_engines").ShowButton("close", () =>
                             {
                                 GameManager.Instance.FreezPlayer(false);
                                 GameManager.Instance.Unpause();
                             });
                         }).ShowButton("fuel", () =>
                         {
                             ((uMyGUI_PopupDragdrap)uMyGUI_PopupManager.Instance.ShowPopup("dragdrop")).ShowDragdropPanel("craft_fuel").ShowButton("close", () =>
                             {
                                 GameManager.Instance.FreezPlayer(false);
                                 GameManager.Instance.Unpause();
                             });
                         }).ShowButton("close", () =>
                         {
                             GameManager.Instance.FreezPlayer(false);
                             GameManager.Instance.Unpause();
                         });

                     }).ShowButton("weapon", () =>
                     {
                         uMyGUI_PopupButtons p = ((uMyGUI_PopupText)uMyGUI_PopupManager.Instance.ShowPopup("popup")).SetText("Are you sure?", "Upgrade Weapon\nSilver -100").ShowButton("no", () =>
                         {
                             GameManager.Instance.FreezPlayer(false);
                             GameManager.Instance.Unpause();
                         });
                         if (GameManager.Instance.Silver >= 100)
                         {
                             p.ShowButton("yes", () =>
                             {
                                 GameManager.Instance.RemoveSilver(100);
                                 GameManager.Instance.UpgradeWeapon();
                                 NotificationText.Instance.AddNotification("Remove 100 Silver");
                                 NotificationText.Instance.AddNotification("Weapon Upgraded!!!");
                                 GameManager.Instance.FreezPlayer(false);
                                 GameManager.Instance.Unpause();
                             });
                         }
                     }).ShowButton("close", () =>
                     {
                         GameManager.Instance.FreezPlayer(false);
                         GameManager.Instance.Unpause();
                     });
                }
            }
            else if (name.StartsWith("computer3"))
            {
                HandPanel.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GameManager.Instance.FreezPlayer(true);
                    GameManager.Instance.Pause();
                    uMyGUI_PopupButtons popup = ((uMyGUI_PopupText)uMyGUI_PopupManager.Instance.ShowPopup("computer3")).ShowButton("close", () =>
                    {
                        GameManager.Instance.FreezPlayer(false);
                        GameManager.Instance.Unpause();
                    });

                    int c = GameManager.Instance.Copper;
                    int s = GameManager.Instance.Silver;
                    int g = GameManager.Instance.Gold;
                    if (c >= 50 && s >= 20 && g >= 10)
                    {
                        int pc = 50;
                        int ps = 20;
                        int pg = 10;
                        if (!InventoryManager.Instance.HasItem(0))
                        {
                            popup.ShowButton("redkeycard", () =>
                            {
                                ((uMyGUI_PopupText)uMyGUI_PopupManager.Instance.ShowPopup("popup")).SetText("Are you sure?", "Copper -" + pc + "\nSilver -" + ps + "\nGold -" + pg).ShowButton("yes", () =>
                                 {
                                     GameManager.Instance.RemoveCopper(pc);
                                     GameManager.Instance.RemoveSilver(ps);
                                     GameManager.Instance.RemoveGold(pg);
                                     InventoryManager.Instance.AddItem(0);
                                     NotificationText.Instance.AddNotification("Remove " + pc + "Copper");
                                     NotificationText.Instance.AddNotification("Remove " + ps + "Silver");
                                     NotificationText.Instance.AddNotification("Remove " + pg + "Gold");
                                     NotificationText.Instance.AddNotification("<Red Keycard> Added!!!");
                                     GameManager.Instance.FreezPlayer(false);
                                     GameManager.Instance.Unpause();
                                 }).ShowButton("no", () =>
                                 {
                                     GameManager.Instance.FreezPlayer(false);
                                     GameManager.Instance.Unpause();
                                 });

                            });
                        }
                        if (!InventoryManager.Instance.HasItem(1))
                        {
                            popup.ShowButton("greenkeycard", () =>
                            {
                                ((uMyGUI_PopupText)uMyGUI_PopupManager.Instance.ShowPopup("popup")).SetText("Are you sure?", "Copper -" + pc + "\nSilver -" + ps + "\nGold -" + pg).ShowButton("yes", () =>
                                {
                                    GameManager.Instance.RemoveCopper(pc);
                                    GameManager.Instance.RemoveSilver(ps);
                                    GameManager.Instance.RemoveGold(pg);
                                    InventoryManager.Instance.AddItem(1);
                                    NotificationText.Instance.AddNotification("Remove " + pc + "Copper");
                                    NotificationText.Instance.AddNotification("Remove " + ps + "Silver");
                                    NotificationText.Instance.AddNotification("Remove " + pg + "Gold");
                                    NotificationText.Instance.AddNotification("<Green Keycard> Added!!!");
                                    GameManager.Instance.FreezPlayer(false);
                                    GameManager.Instance.Unpause();
                                }).ShowButton("no", () =>
                                {
                                    GameManager.Instance.FreezPlayer(false);
                                    GameManager.Instance.Unpause();
                                });
                            });
                        }
                    }
                    if (s >= 200 * GameManager.Instance.gun.level)
                    {
                        popup.ShowButton("gun", () =>
                        {
                            ((uMyGUI_PopupText)uMyGUI_PopupManager.Instance.ShowPopup("popup")).SetText("Are you sure?", "Silver -200").ShowButton("yes", () =>
                            {
                                GameManager.Instance.RemoveSilver(200);
                                GameManager.Instance.UpgradeWeapon();
                                NotificationText.Instance.AddNotification("Remove 200 Silver");
                                NotificationText.Instance.AddNotification("Weapon Upgraded!!!");
                                GameManager.Instance.FreezPlayer(false);
                                GameManager.Instance.Unpause();
                            }).ShowButton("no", () =>
                            {
                                GameManager.Instance.FreezPlayer(false);
                                GameManager.Instance.Unpause();
                            });
                        });
                    }
                    // control chip
                    if (g >= 40 && !InventoryManager.Instance.HasItem(6))
                    {
                        popup.ShowButton("controlchip1", () =>
                        {
                            ((uMyGUI_PopupText)uMyGUI_PopupManager.Instance.ShowPopup("popup")).SetText("Are you sure?", "Gold -40").ShowButton("yes", () =>
                            {
                                GameManager.Instance.RemoveGold(40);
                                InventoryManager.Instance.AddItem(6);
                                NotificationText.Instance.AddNotification("Remove 40 Gold");
                                NotificationText.Instance.AddNotification("<Control Chip Part 1> added!!");
                                GameManager.Instance.FreezPlayer(false);
                                GameManager.Instance.Unpause();
                            }).ShowButton("no", () =>
                            {
                                GameManager.Instance.FreezPlayer(false);
                                GameManager.Instance.Unpause();
                            });
                        });
                    }
                    if (g >= 100 && !InventoryManager.Instance.HasItem(7))
                    {
                        popup.ShowButton("controlchip2", () =>
                        {
                            ((uMyGUI_PopupText)uMyGUI_PopupManager.Instance.ShowPopup("popup")).SetText("Are you sure?", "Gold -100").ShowButton("yes", () =>
                        {
                            GameManager.Instance.RemoveGold(100);
                            InventoryManager.Instance.AddItem(7);
                            NotificationText.Instance.AddNotification("Remove 100 Gold");
                            NotificationText.Instance.AddNotification("<Control Chip Part 2> added!!");
                            GameManager.Instance.FreezPlayer(false);
                            GameManager.Instance.Unpause();
                        }).ShowButton("no", () =>
                        {
                            GameManager.Instance.FreezPlayer(false);
                            GameManager.Instance.Unpause();
                        });
                        });
                    }
                    if (g >= 200 && !InventoryManager.Instance.HasItem(8))
                    {
                        popup.ShowButton("controlchip3", () =>
                        {
                            ((uMyGUI_PopupText)uMyGUI_PopupManager.Instance.ShowPopup("popup")).SetText("Are you sure?", "Gold -200").ShowButton("yes", () =>
                        {
                            GameManager.Instance.RemoveGold(200);
                            InventoryManager.Instance.AddItem(8);
                            NotificationText.Instance.AddNotification("Remove 200 Gold");
                            NotificationText.Instance.AddNotification("<Control Chip Part 3> added!!");
                            GameManager.Instance.FreezPlayer(false);
                            GameManager.Instance.Unpause();
                        }).ShowButton("no", () =>
                        {
                            GameManager.Instance.FreezPlayer(false);
                            GameManager.Instance.Unpause();
                        });
                        });
                    }
                    // navigator
                    if (g >= 40 && !InventoryManager.Instance.HasItem(9))
                    {
                        popup.ShowButton("navigator1", () =>
                        {
                            ((uMyGUI_PopupText)uMyGUI_PopupManager.Instance.ShowPopup("popup")).SetText("Are you sure?", "Gold -40").ShowButton("yes", () =>
                        {
                            GameManager.Instance.RemoveGold(40);
                            InventoryManager.Instance.AddItem(9);
                            NotificationText.Instance.AddNotification("Remove 40 Gold");
                            NotificationText.Instance.AddNotification("<Navigator Part 1> added!!");
                            GameManager.Instance.FreezPlayer(false);
                            GameManager.Instance.Unpause();
                        }).ShowButton("no", () =>
                        {
                            GameManager.Instance.FreezPlayer(false);
                            GameManager.Instance.Unpause();
                        });
                        });
                    }
                    if (g >= 100 && !InventoryManager.Instance.HasItem(10))
                    {
                        popup.ShowButton("navigator2", () =>
                        {
                            ((uMyGUI_PopupText)uMyGUI_PopupManager.Instance.ShowPopup("popup")).SetText("Are you sure?", "Gold -100").ShowButton("yes", () =>
                        {
                            GameManager.Instance.RemoveGold(100);
                            InventoryManager.Instance.AddItem(10);
                            NotificationText.Instance.AddNotification("Remove 100 Gold");
                            NotificationText.Instance.AddNotification("<Navigator Part 2> added!!");
                            GameManager.Instance.FreezPlayer(false);
                            GameManager.Instance.Unpause();
                        }).ShowButton("no", () =>
                        {
                            GameManager.Instance.FreezPlayer(false);
                            GameManager.Instance.Unpause();
                        });
                        });
                    }
                    if (g >= 200 && !InventoryManager.Instance.HasItem(11))
                    {
                        popup.ShowButton("navigator3", () =>
                        {
                            ((uMyGUI_PopupText)uMyGUI_PopupManager.Instance.ShowPopup("popup")).SetText("Are you sure?", "Gold -200").ShowButton("yes", () =>
                        {
                            GameManager.Instance.RemoveGold(200);
                            InventoryManager.Instance.AddItem(11);
                            NotificationText.Instance.AddNotification("Remove 200 Gold");
                            NotificationText.Instance.AddNotification("<Navigator Part 3> added!!");
                            GameManager.Instance.FreezPlayer(false);
                            GameManager.Instance.Unpause();
                        }).ShowButton("no", () =>
                        {
                            GameManager.Instance.FreezPlayer(false);
                            GameManager.Instance.Unpause();
                        });
                        });
                    }
                    // engines
                    if (g >= 40 && !InventoryManager.Instance.HasItem(12))
                    {
                        popup.ShowButton("engine1", () =>
                        {
                            ((uMyGUI_PopupText)uMyGUI_PopupManager.Instance.ShowPopup("popup")).SetText("Are you sure?", "Gold -40").ShowButton("yes", () =>
                        {
                            GameManager.Instance.RemoveGold(40);
                            InventoryManager.Instance.AddItem(12);
                            NotificationText.Instance.AddNotification("Remove 40 Gold");
                            NotificationText.Instance.AddNotification("<Engine Part 1> added!!");
                            GameManager.Instance.FreezPlayer(false);
                            GameManager.Instance.Unpause();
                        }).ShowButton("no", () =>
                        {
                            GameManager.Instance.FreezPlayer(false);
                            GameManager.Instance.Unpause();
                        });
                        });
                    }
                    if (g >= 100 && !InventoryManager.Instance.HasItem(13))
                    {
                        popup.ShowButton("engine2", () =>
                        {
                            ((uMyGUI_PopupText)uMyGUI_PopupManager.Instance.ShowPopup("popup")).SetText("Are you sure?", "Gold -100").ShowButton("yes", () =>
                        {
                            GameManager.Instance.RemoveGold(100);
                            InventoryManager.Instance.AddItem(13);
                            NotificationText.Instance.AddNotification("Remove 100 Gold");
                            NotificationText.Instance.AddNotification("<Engine Part 2> added!!");
                            GameManager.Instance.FreezPlayer(false);
                            GameManager.Instance.Unpause();
                        }).ShowButton("no", () =>
                        {
                            GameManager.Instance.FreezPlayer(false);
                            GameManager.Instance.Unpause();
                        });
                        });
                    }
                    if (g >= 200 && !InventoryManager.Instance.HasItem(14))
                    {
                        popup.ShowButton("engine3", () =>
                        {
                            ((uMyGUI_PopupText)uMyGUI_PopupManager.Instance.ShowPopup("popup")).SetText("Are you sure?", "Gold -200").ShowButton("yes", () =>
                        {
                            GameManager.Instance.RemoveGold(200);
                            InventoryManager.Instance.AddItem(14);
                            NotificationText.Instance.AddNotification("Remove 200 Gold");
                            NotificationText.Instance.AddNotification("<Engine Part 3> added!!");
                            GameManager.Instance.FreezPlayer(false);
                            GameManager.Instance.Unpause();
                        }).ShowButton("no", () =>
                        {
                            GameManager.Instance.FreezPlayer(false);
                            GameManager.Instance.Unpause();
                        });
                        });
                    }
                    // fuel
                    if (g >= 40 && !InventoryManager.Instance.HasItem(15))
                    {
                        popup.ShowButton("fuel1", () =>
                        {
                            ((uMyGUI_PopupText)uMyGUI_PopupManager.Instance.ShowPopup("popup")).SetText("Are you sure?", "Gold -40").ShowButton("yes", () =>
                        {
                            GameManager.Instance.RemoveGold(40);
                            InventoryManager.Instance.AddItem(15);
                            NotificationText.Instance.AddNotification("Remove 40 Gold");
                            NotificationText.Instance.AddNotification("<Fuel Ingredient 1> added!!");
                            GameManager.Instance.FreezPlayer(false);
                            GameManager.Instance.Unpause();
                        }).ShowButton("no", () =>
                        {
                            GameManager.Instance.FreezPlayer(false);
                            GameManager.Instance.Unpause();
                        });
                        });
                    }
                    if (g >= 100 && !InventoryManager.Instance.HasItem(16))
                    {
                        popup.ShowButton("fuel2", () =>
                        {
                            ((uMyGUI_PopupText)uMyGUI_PopupManager.Instance.ShowPopup("popup")).SetText("Are you sure?", "Gold -100").ShowButton("yes", () =>
                        {
                            GameManager.Instance.RemoveGold(100);
                            InventoryManager.Instance.AddItem(16);
                            NotificationText.Instance.AddNotification("Remove 100 Gold");
                            NotificationText.Instance.AddNotification("<Fuel Ingredient 2> added!!");
                            GameManager.Instance.FreezPlayer(false);
                            GameManager.Instance.Unpause();
                        }).ShowButton("no", () =>
                        {
                            GameManager.Instance.FreezPlayer(false);
                            GameManager.Instance.Unpause();
                        });
                        });
                    }
                    if (g >= 200 && !InventoryManager.Instance.HasItem(17))
                    {
                        popup.ShowButton("fuel3", () =>
                        {
                            ((uMyGUI_PopupText)uMyGUI_PopupManager.Instance.ShowPopup("popup")).SetText("Are you sure?", "Gold -200").ShowButton("yes", () =>
                        {
                            GameManager.Instance.RemoveGold(200);
                            InventoryManager.Instance.AddItem(17);
                            NotificationText.Instance.AddNotification("Remove 200 Gold");
                            NotificationText.Instance.AddNotification("<Fuel Ingredient 3> added!!");
                            GameManager.Instance.FreezPlayer(false);
                            GameManager.Instance.Unpause();
                        }).ShowButton("no", () =>
                        {
                            GameManager.Instance.FreezPlayer(false);
                            GameManager.Instance.Unpause();
                        });
                        });
                    }
                }
            }
            else if (name.StartsWith("excavator1"))
            {
                HandPanel.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (!GameManager.Instance.ext[0].startedFlag)
                    {
                        GameManager.Instance.FreezPlayer(true);
                        GameManager.Instance.Pause();

                        ((uMyGUI_PopupText)uMyGUI_PopupManager.Instance.ShowPopup("excavator")).SetText("Excavator01", "Level " + GameManager.Instance.ext[0].level).ShowButton("copper", () =>
                        {
                            GameManager.Instance.StartExcavator(0, 100, 0, 0);
                            ExcavatorControl.Instance.ExcavatorOn(0);
                            GameManager.Instance.FreezPlayer(false);
                            GameManager.Instance.Unpause();
                            if (excavatorFirst)
                            {
                                EnemyManager.Instance.AddEnemy(0);
                                NotificationText.Instance.AddNotification("Enemy Appear Take Care");
                                excavatorFirst = false;
                            }
                        }).ShowButton("silver", () =>
                        {
                            GameManager.Instance.StartExcavator(0, 0, 60, 0);
                            ExcavatorControl.Instance.ExcavatorOn(0);
                            GameManager.Instance.FreezPlayer(false);
                            GameManager.Instance.Unpause();
                            if (excavatorFirst)
                            {
                                EnemyManager.Instance.AddEnemy(0);
                                NotificationText.Instance.AddNotification("Enemy Appear Take Care");
                                excavatorFirst = false;
                            }
                        }).ShowButton("gold", () =>
                        {
                            GameManager.Instance.StartExcavator(0, 0, 0, 10);
                            ExcavatorControl.Instance.ExcavatorOn(0);
                            GameManager.Instance.FreezPlayer(false);
                            GameManager.Instance.Unpause();
                            if (excavatorFirst)
                            {
                                EnemyManager.Instance.AddEnemy(0);
                                NotificationText.Instance.AddNotification("Enemy Appear Take Care");
                                excavatorFirst = false;
                            }
                        }).ShowButton("close", () =>
                        {
                            GameManager.Instance.FreezPlayer(false);
                            GameManager.Instance.Unpause();
                        });
                    }
                    else
                    {
                        if (GameManager.Instance.ext[0].finishedFlag)
                        {
                            Excavator e = GameManager.Instance.ext[0];
                            e.startedFlag = false;
                            e.finishedFlag = false;
                            GameManager.Instance.AddCopper(e.CopperPerMin);
                            GameManager.Instance.AddSilver(e.SilverPerMin);
                            GameManager.Instance.AddGold(e.GoldPerMin);
                            //GameManager.Instance.RestartExcavator(0);
                            if (e.CopperPerMin > 0)
                            {
                                NotificationText.Instance.AddNotification("Copper + " + e.CopperPerMin);
                            }
                            if (e.SilverPerMin > 0)
                            {
                                NotificationText.Instance.AddNotification("Silver + " + e.SilverPerMin);
                            }
                            if (e.GoldPerMin > 0)
                            {
                                NotificationText.Instance.AddNotification("Gold + " + e.GoldPerMin);
                            }
                            e.progressWheel.value = 0;
                        }
                    }
                }
            }
            else if (name.StartsWith("excavator2"))
            {
                HandPanel.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (!GameManager.Instance.ext[1].startedFlag)
                    {
                        GameManager.Instance.FreezPlayer(true);
                        GameManager.Instance.Pause();
                        ((uMyGUI_PopupText)uMyGUI_PopupManager.Instance.ShowPopup("excavator")).SetText("Excavator02", "Level " + GameManager.Instance.ext[1].level).ShowButton("copper", () =>
                        {
                            GameManager.Instance.StartExcavator(1, 100, 0, 0);
                            ExcavatorControl.Instance.ExcavatorOn(1);
                            GameManager.Instance.FreezPlayer(false);
                            GameManager.Instance.Unpause();
                        }).ShowButton("silver", () =>
                        {
                            GameManager.Instance.StartExcavator(1, 0, 60, 0);
                            ExcavatorControl.Instance.ExcavatorOn(1);
                            GameManager.Instance.FreezPlayer(false);
                            GameManager.Instance.Unpause();
                        }).ShowButton("gold", () =>
                        {
                            GameManager.Instance.StartExcavator(1, 0, 0, 10);
                            ExcavatorControl.Instance.ExcavatorOn(1);
                            GameManager.Instance.FreezPlayer(false);
                            GameManager.Instance.Unpause();
                        }).ShowButton("close", () =>
                        {
                            GameManager.Instance.FreezPlayer(false);
                            GameManager.Instance.Unpause();
                        });
                    }
                    else
                    {
                        if (GameManager.Instance.ext[1].finishedFlag)
                        {
                            Excavator e = GameManager.Instance.ext[1];
                            e.startedFlag = false;
                            e.finishedFlag = false;
                            GameManager.Instance.AddCopper(e.CopperPerMin);
                            GameManager.Instance.AddSilver(e.SilverPerMin);
                            GameManager.Instance.AddGold(e.GoldPerMin);
                            //GameManager.Instance.RestartExcavator(1);
                            if (e.CopperPerMin > 0)
                            {
                                NotificationText.Instance.AddNotification("Copper + " + e.CopperPerMin);
                            }
                            if (e.SilverPerMin > 0)
                            {
                                NotificationText.Instance.AddNotification("Silver + " + e.SilverPerMin);
                            }
                            if (e.GoldPerMin > 0)
                            {
                                NotificationText.Instance.AddNotification("Gold + " + e.GoldPerMin);
                            }
                            e.progressWheel.value = 0;
                        }
                    }

                }

            }
            else if (name.StartsWith("excavator3"))
            {
                HandPanel.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GameManager.Instance.FreezPlayer(true);
                    GameManager.Instance.Pause();
                    ((uMyGUI_PopupText)uMyGUI_PopupManager.Instance.ShowPopup("popup")).SetText("Excavator03<Broken>", "<Broken...>").ShowButton("ok", () =>
                    {

                        GameManager.Instance.FreezPlayer(false);
                        GameManager.Instance.Unpause();
                    });
                }
            }
            else if (name.StartsWith("rocket"))
            {
                HandPanel.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GameManager.Instance.FreezPlayer(true);
                    GameManager.Instance.Pause();

                    ((uMyGUI_PopupText)uMyGUI_PopupManager.Instance.ShowPopup("rocket")).SetText("Rocket", "<Broken...>").ShowButton("end", () =>
                    {
                        NotificationText.Instance.AddNotification("Cant");
                        GameManager.Instance.FreezPlayer(false);
                        GameManager.Instance.Unpause();
                    }).ShowButton("fix", () =>
                    {
                        ((uMyGUI_PopupDragdrap)uMyGUI_PopupManager.Instance.ShowPopup("dragdrop")).ShowDragdropPanel("rocket").ShowButton("close", () =>
                        {
                            GameManager.Instance.FreezPlayer(false);
                            GameManager.Instance.Unpause();
                        });
                    }).ShowButton("close", () =>
                    {
                        GameManager.Instance.FreezPlayer(false);
                        GameManager.Instance.Unpause();
                    });
                }
            }
            else if (name.StartsWith("poster1"))
            {
                GameManager.Instance.AddCopper(50);
                hit.collider.gameObject.GetComponent<BoxCollider>().enabled = false;
                NotificationText.Instance.AddNotification("ได้รับ ทองแดง 50");
            }
            else if (name.StartsWith("poster2"))
            {
                GameManager.Instance.AddSilver(30);
                hit.collider.gameObject.GetComponent<BoxCollider>().enabled = false;
                NotificationText.Instance.AddNotification("ได้รับ แร่เงิน 30");
            }
            else if (name.StartsWith("poster3"))
            {
                GameManager.Instance.AddGold(5);
                hit.collider.gameObject.GetComponent<BoxCollider>().enabled = false;
                NotificationText.Instance.AddNotification("ได้รับ แร่ทอง 5");
            }
            else
            {
                hideAllUI();
            }
        }
        else
        {
            hideAllUI();
        }
    }

    void hideAllUI()
    {
        HandPanel.SetActive(false);
    }
}
