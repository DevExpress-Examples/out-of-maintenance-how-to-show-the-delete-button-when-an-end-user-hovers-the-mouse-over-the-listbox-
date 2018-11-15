<!-- default file list -->
*Files to look at*:

* [DeleteHelper.cs](./CS/DeleteItemFromListBox/DeleteHelper.cs) (VB: [DeleteHelper.vb](./VB/DeleteItemFromListBox/DeleteHelper.vb))
* [Form1.cs](./CS/DeleteItemFromListBox/Form1.cs) (VB: [Form1.vb](./VB/DeleteItemFromListBox/Form1.vb))
* [Program.cs](./CS/DeleteItemFromListBox/Program.cs) (VB: [Program.vb](./VB/DeleteItemFromListBox/Program.vb))
<!-- default file list end -->
# How to show the delete button when an end-user hovers the mouse over the ListBox item


<p>This example demonstrates how to show the delete button when an end-user hovers the mouse over the ListBox item. The main idea is to handle the DrawItem event, which is used for drawing a custom view of an item. The redraw region of ListBox rises during the mouse move. ButtonEditPainter is used for drawing the delete button.</p>

<br/>


