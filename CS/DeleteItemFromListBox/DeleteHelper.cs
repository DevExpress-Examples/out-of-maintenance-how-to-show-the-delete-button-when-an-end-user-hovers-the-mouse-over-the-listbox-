using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using System.Windows.Forms;
using System.Drawing;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors.ViewInfo;

namespace DeleteItemFromListBox
{
    public class DeleteHelper
    {
        ListBoxControl _list;
        int itemIndex = -1;
        RepositoryItemButtonEdit repository;
        EditorButton editorButton;
        int size = 18;
        ObjectState state;

        public DeleteHelper(ListBoxControl list)
        {
            _list = list;
            _list.MouseMove += _MouseMove;
            _list.DrawItem += _DrawItem;
            _list.MouseClick += _MouseClick;
            _list.MouseDown += _MouseDown;
            _list.ItemHeight = size + 1;
            repository = new RepositoryItemButtonEdit();
            repository.Buttons.Clear();
            editorButton = new EditorButton(ButtonPredefines.Close);
            repository.Buttons.Add(editorButton);
            repository.TextEditStyle = TextEditStyles.HideTextEditor;
            repository.BorderStyle = BorderStyles.NoBorder;
        }

        void _MouseDown(object sender, MouseEventArgs e)
        {
            if (itemIndex < 0)
                return;
            if (IsButton(e.Location))
            {
                state = ObjectState.Pressed;
                Redraw();
            }
        }

        void _MouseClick(object sender, MouseEventArgs e)
        {
            if (itemIndex < 0)
                return;
            if (IsButton(e.Location))
                _list.Items.RemoveAt(itemIndex);
        }

        private void DrawButton(ListBoxDrawItemEventArgs e)
        {
            Rectangle bounds = GetRectangle(e.Bounds);
            ButtonEditViewInfo buttonEditViewInfo = (ButtonEditViewInfo)repository.CreateViewInfo();
            buttonEditViewInfo.Bounds = bounds;
            buttonEditViewInfo.CalcViewInfo(e.Graphics);
            DevExpress.XtraEditors.Drawing.EditorButtonObjectInfoArgs buttonInfoByButton = buttonEditViewInfo.ButtonInfoByButton(editorButton);
            buttonInfoByButton.State = state;
            DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs info = new DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs(buttonEditViewInfo, e.Cache, bounds);
            repository.CreatePainter().Draw(info);
        }

        private static void DrawContent(ListBoxDrawItemEventArgs e)
        {
            e.Appearance.FillRectangle(e.Cache, e.Bounds);
            Rectangle textRect = Rectangle.Inflate(e.Bounds, -2, 0);
            e.Appearance.DrawString(e.Cache, e.Item.ToString(), textRect);
        }

        void _DrawItem(object sender, ListBoxDrawItemEventArgs e)
        {
            if (itemIndex < 0 || e.Index != itemIndex)
                return;
            DrawContent(e);
            DrawButton(e);
            e.Handled = true;
        }

        private void _MouseMove(object sender, MouseEventArgs e)
        {
            int newIndex = _list.IndexFromPoint(e.Location);
            if (itemIndex >= 0)
                Redraw();
            itemIndex = newIndex;
            if (itemIndex < 0)
                return;
            if (IsButton(e.Location))
                state = ObjectState.Hot;
            else
                state = ObjectState.Normal;
            Redraw();
        }

        Rectangle GetRectangle(Rectangle source)
        {
            Rectangle result = source;
            result.X = source.Right - size;
            result.Width = size;
            result.Height = size;
            return result;
        }

        void Redraw()
        {
            _list.Invalidate(_list.GetItemRectangle(itemIndex));
        }

        bool IsButton(Point p)
        {
            return GetRectangle(_list.GetItemRectangle(itemIndex)).Contains(p);
        }
    }
}
