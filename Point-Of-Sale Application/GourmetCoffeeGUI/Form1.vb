Imports GourmetCoffee

Public Class Form1

    Dim gourmetCoffee As New GourmetCoffee.GourmetCoffee()
    Dim product As Product

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gourmetCoffee.LoadCatalog()

        For Each prod As Product In gourmetCoffee.catalog
            lstCatalog.Items.Add(prod.Code)
        Next

        lstCatalog.SelectedIndex = 0
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstCatalog.SelectedIndexChanged
        product = gourmetCoffee.catalog.GetProduct(lstCatalog.SelectedItem)

        lblOne.Text = "Code:"
        lblTwo.Text = "Description:"
        lblThree.Text = "Price:"

        txtOne.Text = product.Code
        txtTwo.Text = product.Description
        txtThree.Text = product.Price

        lblOne.Visible = True
        lblTwo.Visible = True
        lblThree.Visible = True
        lblFour.Visible = False
        lblFive.Visible = False
        lblSix.Visible = False
        lblSeven.Visible = False
        lblEight.Visible = False
        lblNine.Visible = False

        txtOne.Visible = True
        txtTwo.Visible = True
        txtThree.Visible = True
        txtFour.Visible = False
        txtFive.Visible = False
        txtSix.Visible = False
        txtSeven.Visible = False
        txtEight.Visible = False
        txtNine.Visible = False

        If TypeOf product Is Coffee Then
            lblFour.Text = "Origin:"
            lblFive.Text = "Roast:"
            lblSix.Text = "Flavor:"
            lblSeven.Text = "Aroma:"
            lblEight.Text = "Acidity:"
            lblNine.Text = "Body:"

            txtFour.Text = TryCast(product, Coffee).Origin
            txtFive.Text = TryCast(product, Coffee).Roast
            txtSix.Text = TryCast(product, Coffee).Flavor
            txtSeven.Text = TryCast(product, Coffee).Aroma
            txtEight.Text = TryCast(product, Coffee).Acidity
            txtNine.Text = TryCast(product, Coffee).Body

            lblFour.Visible = True
            lblFive.Visible = True
            lblSix.Visible = True
            lblSeven.Visible = True
            lblEight.Visible = True
            lblNine.Visible = True

            txtFour.Visible = True
            txtFive.Visible = True
            txtSix.Visible = True
            txtSeven.Visible = True
            txtEight.Visible = True
            txtNine.Visible = True
        End If

        If TypeOf product Is CoffeeBrewer Then
            lblFour.Text = "Model:"
            lblFive.Text = "Water Supply:"
            lblSix.Text = "Number of Cups:"

            txtFour.Text = TryCast(product, CoffeeBrewer).Model
            txtFive.Text = TryCast(product, CoffeeBrewer).WaterSupply
            txtSix.Text = TryCast(product, CoffeeBrewer).NumberOfCups

            lblFour.Visible = True
            lblFive.Visible = True
            lblSix.Visible = True
            lblSeven.Visible = False
            lblEight.Visible = False
            lblNine.Visible = False

            txtFour.Visible = True
            txtFive.Visible = True
            txtSix.Visible = True
            txtSeven.Visible = False
            txtEight.Visible = False
            txtNine.Visible = False
        End If

        numQuantity.Value = 1

        txtNumberOfOrders.Text = gourmetCoffee.DisplayNumberOfOrders(product.Code)
        txtTotalQuantitySold.Text = gourmetCoffee.DisplayTotalQuantityOfProducts(product.Code)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddModify.Click
        gourmetCoffee.AddModifyProduct(lstCatalog.SelectedItem, numQuantity.Value)

        PopulateOrderItems()

        numQuantity.Value = 1

        btnRegister.Enabled = True
        btnRemove.Enabled = True
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        For Each orderItem As OrderItem In gourmetCoffee.currentOrder
            If lstCurrentOrder.SelectedItem.Equals(orderItem.ToString()) Then
                gourmetCoffee.RemoveProduct(orderItem.Product.Code)

                Exit For
            End If
        Next

        PopulateOrderItems()

        If lstCurrentOrder.Items.Count = 0 Then
            btnRegister.Enabled = False
            btnRemove.Enabled = False
        End If
    End Sub

    Private Sub PopulateOrderItems()
        Dim total As Double

        lstCurrentOrder.Items.Clear()
        total = 0

        For Each orderItem As OrderItem In gourmetCoffee.currentOrder
            lstCurrentOrder.Items.Add(orderItem.ToString())

            total = total + (orderItem.Product.Price * orderItem.Quantity)
        Next

        txtTotal.Text = total
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegister.Click
        Dim orderNumber As Integer

        gourmetCoffee.SaleOrder()

        lstSales.Items.Clear()

        orderNumber = 0

        For Each order As Order In gourmetCoffee.sales
            orderNumber = orderNumber + 1

            lstSales.Items.Add("Order Number: " & orderNumber)
            lstSales.Items.Add("---------------")

            For Each orderItem As OrderItem In order
                lstSales.Items.Add(orderItem.ToString())
            Next

            lstSales.Items.Add("")
        Next

        PopulateOrderItems()

        txtNumberOfOrders.Text = gourmetCoffee.DisplayNumberOfOrders(product.Code)
        txtTotalQuantitySold.Text = gourmetCoffee.DisplayTotalQuantityOfProducts(product.Code)

        btnRegister.Enabled = False
        btnRemove.Enabled = False
    End Sub
End Class
