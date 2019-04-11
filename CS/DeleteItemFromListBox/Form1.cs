using DevExpress.XtraEditors;

namespace DeleteItemFromListBox {
    public partial class Form1 : XtraForm {
        public Form1() {
            InitializeComponent();

            for (int i = 0; i < 10; i++)
                listBoxControl1.Items.Add("Click the context button to delete this record " + i);            

            listBoxControl1.ContextButtonClick += ListBoxControl1_ContextButtonClick;
        }

        private void ListBoxControl1_ContextButtonClick(object sender, DevExpress.Utils.ContextItemClickEventArgs e) {
            var listBoxControl = sender as ListBoxControl;
            listBoxControl.Items.Remove(e.DataItem);
        }
    }
}
