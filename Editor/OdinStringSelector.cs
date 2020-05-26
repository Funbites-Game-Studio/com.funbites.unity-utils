namespace Funbites.UnityUtils.Editor {
    public class OdinStringSelector : Sirenix.OdinInspector.Editor.OdinSelector<string>
    {
        private string[] options;

        public OdinStringSelector(string[] options)
        {
            this.options = options;
        }

        protected override void BuildSelectionTree(Sirenix.OdinInspector.Editor.OdinMenuTree tree)
        {
            tree.Selection.SupportsMultiSelect = false;
            tree.Config.DrawSearchToolbar = true;
            tree.Config.AutoFocusSearchBar = true;
            tree.Config.DrawScrollView = true;
            tree.AddRange(options, x => x);
            EnableSingleClickToSelect();
        }
    }  
}