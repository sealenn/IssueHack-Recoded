using System;
using MelonLoader;
using UnityEngine;

[assembly: MelonInfo(typeof(L0LeRModMenu.MainMod), "Issue's Hack Recoded", "1.0.0", "Sealeen")]
[assembly: MelonGame(null, null)]

namespace L0LeRModMenu
{
    public class MainMod : MelonMod
    {
        private bool _isOpen = false;
        private Rect _windowRect = new Rect(100, 100, 450, 500);
        private int _currentTab = 0;

        // bools
        // baby bools
        private bool _babyCallGranny = false;
        private bool _forceBabyChase = false;

        // nanny bools
        private bool _grannyAtDishes = false;
        private bool _grannyAtPiano = false;
        private string _grannyDoorDistanceStr = "3.0";
        private string _grannyKillDistanceStr = "1.5";
        private string _grannyEyesColorStr = "#FF0000";
        private bool _forceGrannyChasingEyes = false;
        private string _grannyViewRangeStr = "40.0";
        private bool _grannyIsAngry = false;
        private bool _grannyIsChasing = false;
        private bool _grannyIsDying = false;
        private bool _grannyIsSearching = false;
        private bool _grannyPlacingTrap = false;
        private string _grannyRunAnimStr = "1.0";
        private string _grannyRunSpeedStr = "4.5";
        private string _grannyWalkAnimStr = "1.0";
        private string _grannyWalkSpeedStr = "2.0";

        // ded bools
        private bool _dedAtCams = false;
        private bool _dedAtRadio = false;
        private string _dedKillDistanceStr = "1.5";
        private string _dedDoorDistanceStr = "3.0";
        private bool _dedInSecurity = false;
        private bool _dedIsAngry = false;
        private bool _dedIsChasing = false;
        private bool _dedIsDying = false;
        private bool _dedPlacingTrap = false;
        private string _dedRunAnimStr = "1.0";
        private string _dedRunSpeedStr = "4.0";
        private bool _dedDroppingTraps = false;
        private string _dedWalkAnimStr = "1.0";
        private string _dedWalkSpeedStr = "1.8";

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Insert))
            {
                _isOpen = !_isOpen;
            }
        }

        public override void OnGUI()
        {
            if (!_isOpen) return;

            GUI.skin.window.normal.textColor = Color.white;
            _windowRect = GUI.Window(0, _windowRect, (GUI.WindowFunction)DrawMenu, "<color=white><b>Issue's Hack Recode</b></color>");
        }

        private void DrawMenu(int windowID)
        {
            GUI.DragWindow(new Rect(0, 0, 450, 20));

            // tabss
            string[] tabs = { "Baby_AI", "Granny_AI", "Grandpa_AI" };
            _currentTab = GUILayout.Toolbar(_currentTab, tabs);

            GUILayout.BeginVertical();
            GUILayout.Space(10);

            switch (_currentTab)
            {
                case 0:
                    DrawBabyTab();
                    break;
                case 1:
                    DrawGrannyTab();
                    break;
                case 2:
                    DrawGrandpaTab();
                    break;
            }

            GUILayout.EndVertical();
        }

        // baby
        private void DrawBabyTab()
        {
            GUILayout.Label("<b>Baby manipulation</b>");

            _babyCallGranny = GUILayout.Toggle(_babyCallGranny, "Granny call");
            _forceBabyChase = GUILayout.Toggle(_forceBabyChase, "Force Baby Chase Player");

            if (GUILayout.Button("Apply", GUILayout.Width(100)))
            {
                var baby = UnityEngine.Object.FindObjectOfType<Il2Cpp.AI_Baby>();
                if (baby != null)
                {
                    baby.CalledGranny = _babyCallGranny;
                    baby.Chasing = _forceBabyChase;
                    MelonLogger.Msg("baby pop");
                }
            }
        }

        // nanny
        private void DrawGrannyTab()
        {
            GUILayout.Label("<b>Granny manipulation</b>");

            _grannyAtDishes = GUILayout.Toggle(_grannyAtDishes, "Force Granny Be At Dishes");
            _grannyAtPiano = GUILayout.Toggle(_grannyAtPiano, "Force Granny Be At Piano");
            _forceGrannyChasingEyes = GUILayout.Toggle(_forceGrannyChasingEyes, "Force Granny Chasing Player (Eyes)");
            _grannyIsAngry = GUILayout.Toggle(_grannyIsAngry, "Force Granny Be Angry");
            _grannyIsChasing = GUILayout.Toggle(_grannyIsChasing, "Force Granny Chasing Player");
            _grannyIsDying = GUILayout.Toggle(_grannyIsDying, "Kill Granny");
            _grannyIsSearching = GUILayout.Toggle(_grannyIsSearching, "Force Granny Searching");
            _grannyPlacingTrap = GUILayout.Toggle(_grannyPlacingTrap, "Force Granny Drop BearTrap");

            GUILayout.Space(5);

            GUILayout.BeginHorizontal();
            GUILayout.Label("Granny DoorDistance:", GUILayout.Width(150));
            _grannyDoorDistanceStr = GUILayout.TextField(_grannyDoorDistanceStr, GUILayout.Width(80));
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Granny KillDistance:", GUILayout.Width(150));
            _grannyKillDistanceStr = GUILayout.TextField(_grannyKillDistanceStr, GUILayout.Width(80));
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Granny Eyes Color:", GUILayout.Width(150));
            _grannyEyesColorStr = GUILayout.TextField(_grannyEyesColorStr, GUILayout.Width(80));
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Granny ViewRange:", GUILayout.Width(150));
            _grannyViewRangeStr = GUILayout.TextField(_grannyViewRangeStr, GUILayout.Width(80));
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Granny RunSpeed / Anim:", GUILayout.Width(150));
            _grannyRunSpeedStr = GUILayout.TextField(_grannyRunSpeedStr, GUILayout.Width(50));
            _grannyRunAnimStr = GUILayout.TextField(_grannyRunAnimStr, GUILayout.Width(50));
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Granny WalkSpeed / Anim:", GUILayout.Width(150));
            _grannyWalkSpeedStr = GUILayout.TextField(_grannyWalkSpeedStr, GUILayout.Width(50));
            _grannyWalkAnimStr = GUILayout.TextField(_grannyWalkAnimStr, GUILayout.Width(50));
            GUILayout.EndHorizontal();

            GUILayout.Space(10);

            if (GUILayout.Button("Apply", GUILayout.Width(100)))
            {
                var granny = UnityEngine.Object.FindObjectOfType<Il2Cpp.AI_Granny>();
                if (granny != null)
                {
                    // bools ?
                    granny.AtDishes = _grannyAtDishes;
                    granny.AtPiano = _grannyAtPiano;
                    granny.IsAngry = _grannyIsAngry;
                    granny.IsChasing = _grannyIsChasing;
                    granny.IsDying = _grannyIsDying;
                    granny.IsSearching = _grannyIsSearching;
                    granny.PlacingTrap = _grannyPlacingTrap;

                    // pars
                    if (float.TryParse(_grannyDoorDistanceStr, out float doorDist)) granny.DoorDistance = doorDist;
                    if (float.TryParse(_grannyKillDistanceStr, out float killDist)) granny.DistanceJumpscare = killDist;
                    if (float.TryParse(_grannyRunAnimStr, out float runAnim)) granny.Run_Anim = runAnim;
                    if (float.TryParse(_grannyRunSpeedStr, out float runSpeed)) granny.Run_Speed = runSpeed;
                    if (float.TryParse(_grannyWalkAnimStr, out float walkAnim)) granny.Walk_Anim = walkAnim;
                    if (float.TryParse(_grannyWalkSpeedStr, out float walkSpeed)) granny.Walk_Speed = walkSpeed;

                    // work
                    var grannyEyes = UnityEngine.Object.FindObjectOfType<Il2Cpp.Eyes_Granny.AI>(); 
                    if (grannyEyes != null)
                    {
                        grannyEyes.PlayerSpotted = _forceGrannyChasingEyes;
                        if (float.TryParse(_grannyViewRangeStr, out float viewRange)) grannyEyes.ViewRange = viewRange;
                        
                        if (ColorUtility.TryParseHtmlString(_grannyEyesColorStr, out Color customColor))
                        {
                        }
                    }

                    MelonLogger.Msg("granny pop");
                }
            }
        }

        // ded
        private void DrawGrandpaTab()
        {
            GUILayout.Label("<b>Ded manipulation</b>");

            _dedAtCams = GUILayout.Toggle(_dedAtCams, "Force Ded Be in Cams");
            _dedAtRadio = GUILayout.Toggle(_dedAtRadio, "Force Ded Dance in Radio");
            _dedInSecurity = GUILayout.Toggle(_dedInSecurity, "Force Ded be in security");
            _dedIsAngry = GUILayout.Toggle(_dedIsAngry, "Force Ded be Angry at Player");
            _dedIsChasing = GUILayout.Toggle(_dedIsChasing, "Force Ded Chase Player");
            _dedIsDying = GUILayout.Toggle(_dedIsDying, "Kill Ded");
            _dedPlacingTrap = GUILayout.Toggle(_dedPlacingTrap, "Force Ded Drop Trap");
            _dedDroppingTraps = GUILayout.Toggle(_dedDroppingTraps, "Force Ded Dropping Trap's");

            GUILayout.Space(5);

            GUILayout.BeginHorizontal();
            GUILayout.Label("Ded DoorDistance:", GUILayout.Width(150));
            _dedDoorDistanceStr = GUILayout.TextField(_dedDoorDistanceStr, GUILayout.Width(80));
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Ded KillDistance:", GUILayout.Width(150));
            _dedKillDistanceStr = GUILayout.TextField(_dedKillDistanceStr, GUILayout.Width(80));
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Ded RunSpeed / Anim:", GUILayout.Width(150));
            _dedRunSpeedStr = GUILayout.TextField(_dedRunSpeedStr, GUILayout.Width(50));
            _dedRunAnimStr = GUILayout.TextField(_dedRunAnimStr, GUILayout.Width(50));
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Ded WalkSpeed / Anim:", GUILayout.Width(150));
            _dedWalkSpeedStr = GUILayout.TextField(_dedWalkSpeedStr, GUILayout.Width(50));
            _dedWalkAnimStr = GUILayout.TextField(_dedWalkAnimStr, GUILayout.Width(50));
            GUILayout.EndHorizontal();

            GUILayout.Space(10);

            if (GUILayout.Button("Apply", GUILayout.Width(100)))
            {
                var grandpa = UnityEngine.Object.FindObjectOfType<Il2Cpp.AI_Grandpa>();
                if (grandpa != null)
                {
                    grandpa.AtCams = _dedAtCams;
                    grandpa.AtRadio = _dedAtRadio;
                    grandpa.InSecurityRoom = _dedInSecurity;
                    grandpa.IsAngry = _dedIsAngry;
                    grandpa.IsChasing = _dedIsChasing;
                    grandpa.IsDying = _dedIsDying;
                    grandpa.PlacingTrap = _dedPlacingTrap;
                    grandpa.TrapPregnant = _dedDroppingTraps;

                    if (float.TryParse(_dedDoorDistanceStr, out float doorDist)) grandpa.DoorDistance = doorDist;
                    if (float.TryParse(_dedKillDistanceStr, out float killDist)) grandpa.DistanceJumpscare = killDist;
                    if (float.TryParse(_dedRunAnimStr, out float runAnim)) grandpa.Run_Anim = runAnim;
                    if (float.TryParse(_dedRunSpeedStr, out float runSpeed)) grandpa.Run_Speed = runSpeed;
                    if (float.TryParse(_dedWalkAnimStr, out float walkAnim)) grandpa.Walk_Anim = walkAnim;
                    if (float.TryParse(_dedWalkSpeedStr, out float walkSpeed)) grandpa.Walk_Speed = walkSpeed;

                    MelonLogger.Msg("ded pop");
                }
            }
        }
    }
}
