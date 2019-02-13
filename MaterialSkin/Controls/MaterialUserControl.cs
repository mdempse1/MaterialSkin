using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaterialSkin.Controls
{
    public class MaterialUserControl : UserControl,
        IMaterialControl
    {
        [Browsable(false)]
        public int Depth { get; set; }
        [Browsable(false)]
        public MaterialSkinManager SkinManager => MaterialSkinManager.Instance;
        [Browsable(false)]
        public MouseState MouseState { get; set; }
        private MaterialForm m_OwnForm = null;
        [Browsable(false)]
        public MaterialForm OwnForm
        {
            get
            {
                if (m_OwnForm == null)
                    m_OwnForm = GetOwnForm(this);
                return m_OwnForm;
            }
        }
        private static MaterialForm GetOwnForm(Control ctrl)
        {
            if (ctrl.Parent != null)
            {
                if (!(ctrl.Parent is MaterialForm form))
                    return GetOwnForm(ctrl.Parent);
                else
                    return form;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// The OnCreateControl
        /// </summary>
        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            ForeColor = SkinManager.GetPrimaryTextColor();
            BackColor = SkinManager.GetControlBackgroundColor();
            BackColorChanged += (sender, args) => ForeColor = SkinManager.GetPrimaryTextColor();
        }
    }
}