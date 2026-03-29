namespace VehicleStoreGUIApp
{
    partial class FrmVehicleStore
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            grpCreateAVehicle = new GroupBox();
            btnCreate = new Button();
            lblPriceError = new Label();
            txtWheels = new TextBox();
            lblYearError = new Label();
            lblWheelsError = new Label();
            lblWheels = new Label();
            lblModelError = new Label();
            txtPrice = new TextBox();
            lblMakeError = new Label();
            rdoVehicle = new RadioButton();
            lblVehicleTypeError = new Label();
            txtYear = new TextBox();
            lblPrice = new Label();
            txtModel = new TextBox();
            rdoPickup = new RadioButton();
            txtMake = new TextBox();
            lblYear = new Label();
            rdoMotorcycle = new RadioButton();
            lblModel = new Label();
            rdoCar = new RadioButton();
            lblMake = new Label();
            grpSpecialtyProperties = new GroupBox();
            lblSpecialtyDecimalError = new Label();
            txtSpecialtyDecimal = new TextBox();
            lblSpecialtyDecimal = new Label();
            rdoSpecialtyNo = new RadioButton();
            lblSpecialtyBooleanError = new Label();
            lblSpecialtyBoolean = new Label();
            rdoSpecialtyYes = new RadioButton();
            contextMenuStrip1 = new ContextMenuStrip(components);
            grpStoreInventory = new GroupBox();
            lstInventory = new ListBox();
            btnAddToCart = new Button();
            grpShoppingCart = new GroupBox();
            lstShoppingCart = new ListBox();
            btnCheckout = new Button();
            contextMenuStrip2 = new ContextMenuStrip(components);
            Total = new Label();
            lblTotal = new Label();
            grpCreateAVehicle.SuspendLayout();
            grpSpecialtyProperties.SuspendLayout();
            grpStoreInventory.SuspendLayout();
            grpShoppingCart.SuspendLayout();
            SuspendLayout();
            // 
            // grpCreateAVehicle
            // 
            grpCreateAVehicle.Controls.Add(btnCreate);
            grpCreateAVehicle.Controls.Add(lblPriceError);
            grpCreateAVehicle.Controls.Add(txtWheels);
            grpCreateAVehicle.Controls.Add(lblYearError);
            grpCreateAVehicle.Controls.Add(lblWheelsError);
            grpCreateAVehicle.Controls.Add(lblWheels);
            grpCreateAVehicle.Controls.Add(lblModelError);
            grpCreateAVehicle.Controls.Add(txtPrice);
            grpCreateAVehicle.Controls.Add(lblMakeError);
            grpCreateAVehicle.Controls.Add(rdoVehicle);
            grpCreateAVehicle.Controls.Add(lblVehicleTypeError);
            grpCreateAVehicle.Controls.Add(txtYear);
            grpCreateAVehicle.Controls.Add(lblPrice);
            grpCreateAVehicle.Controls.Add(txtModel);
            grpCreateAVehicle.Controls.Add(rdoPickup);
            grpCreateAVehicle.Controls.Add(txtMake);
            grpCreateAVehicle.Controls.Add(lblYear);
            grpCreateAVehicle.Controls.Add(rdoMotorcycle);
            grpCreateAVehicle.Controls.Add(lblModel);
            grpCreateAVehicle.Controls.Add(rdoCar);
            grpCreateAVehicle.Controls.Add(lblMake);
            grpCreateAVehicle.Location = new Point(9, 11);
            grpCreateAVehicle.Name = "grpCreateAVehicle";
            grpCreateAVehicle.Size = new Size(219, 420);
            grpCreateAVehicle.TabIndex = 0;
            grpCreateAVehicle.TabStop = false;
            grpCreateAVehicle.Text = "Create a Vehicle";
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(55, 379);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(75, 23);
            btnCreate.TabIndex = 6;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += BtnCreateClickEH;
            // 
            // lblPriceError
            // 
            lblPriceError.AutoSize = true;
            lblPriceError.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPriceError.ForeColor = Color.Red;
            lblPriceError.Location = new Point(55, 292);
            lblPriceError.Name = "lblPriceError";
            lblPriceError.Size = new Size(145, 15);
            lblPriceError.TabIndex = 13;
            lblPriceError.Text = "Please enter a valid price";
            // 
            // txtWheels
            // 
            txtWheels.Location = new Point(65, 322);
            txtWheels.Name = "txtWheels";
            txtWheels.Size = new Size(100, 23);
            txtWheels.TabIndex = 5;
            // 
            // lblYearError
            // 
            lblYearError.AutoSize = true;
            lblYearError.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblYearError.ForeColor = Color.Red;
            lblYearError.Location = new Point(55, 236);
            lblYearError.Name = "lblYearError";
            lblYearError.Size = new Size(141, 15);
            lblYearError.TabIndex = 12;
            lblYearError.Text = "Please enter a valid year";
            // 
            // lblWheelsError
            // 
            lblWheelsError.AutoSize = true;
            lblWheelsError.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWheelsError.ForeColor = Color.Red;
            lblWheelsError.Location = new Point(14, 348);
            lblWheelsError.Name = "lblWheelsError";
            lblWheelsError.Size = new Size(186, 15);
            lblWheelsError.TabIndex = 14;
            lblWheelsError.Text = "Please enter a valid wheel count";
            // 
            // lblWheels
            // 
            lblWheels.AutoSize = true;
            lblWheels.Location = new Point(13, 330);
            lblWheels.Name = "lblWheels";
            lblWheels.Size = new Size(48, 15);
            lblWheels.TabIndex = 5;
            lblWheels.Text = "Wheels:";
            // 
            // lblModelError
            // 
            lblModelError.AutoSize = true;
            lblModelError.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblModelError.ForeColor = Color.Red;
            lblModelError.Location = new Point(55, 182);
            lblModelError.Name = "lblModelError";
            lblModelError.Size = new Size(123, 15);
            lblModelError.TabIndex = 11;
            lblModelError.Text = "Please enter a model";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(65, 266);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(100, 23);
            txtPrice.TabIndex = 4;
            // 
            // lblMakeError
            // 
            lblMakeError.AutoSize = true;
            lblMakeError.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMakeError.ForeColor = Color.Red;
            lblMakeError.Location = new Point(59, 135);
            lblMakeError.Name = "lblMakeError";
            lblMakeError.Size = new Size(119, 15);
            lblMakeError.TabIndex = 10;
            lblMakeError.Text = "Please enter a make";
            // 
            // rdoVehicle
            // 
            rdoVehicle.AutoSize = true;
            rdoVehicle.Location = new Point(80, 55);
            rdoVehicle.Name = "rdoVehicle";
            rdoVehicle.Size = new Size(62, 19);
            rdoVehicle.TabIndex = 3;
            rdoVehicle.TabStop = true;
            rdoVehicle.Text = "Vehicle";
            rdoVehicle.UseVisualStyleBackColor = true;
            // 
            // lblVehicleTypeError
            // 
            lblVehicleTypeError.AutoSize = true;
            lblVehicleTypeError.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVehicleTypeError.ForeColor = Color.Red;
            lblVehicleTypeError.Location = new Point(12, 77);
            lblVehicleTypeError.Name = "lblVehicleTypeError";
            lblVehicleTypeError.Size = new Size(166, 15);
            lblVehicleTypeError.TabIndex = 9;
            lblVehicleTypeError.Text = "Please Choose a Vehicle Type";
            // 
            // txtYear
            // 
            txtYear.Location = new Point(63, 210);
            txtYear.Name = "txtYear";
            txtYear.Size = new Size(100, 23);
            txtYear.TabIndex = 3;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(13, 274);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(36, 15);
            lblPrice.TabIndex = 4;
            lblPrice.Text = "Price:";
            // 
            // txtModel
            // 
            txtModel.Location = new Point(63, 156);
            txtModel.Name = "txtModel";
            txtModel.Size = new Size(100, 23);
            txtModel.TabIndex = 2;
            // 
            // rdoPickup
            // 
            rdoPickup.AutoSize = true;
            rdoPickup.Location = new Point(13, 55);
            rdoPickup.Name = "rdoPickup";
            rdoPickup.Size = new Size(61, 19);
            rdoPickup.TabIndex = 2;
            rdoPickup.TabStop = true;
            rdoPickup.Text = "Pickup";
            rdoPickup.UseVisualStyleBackColor = true;
            rdoPickup.Click += RdoPickupClickEH;
            // 
            // txtMake
            // 
            txtMake.Location = new Point(65, 109);
            txtMake.Name = "txtMake";
            txtMake.Size = new Size(100, 23);
            txtMake.TabIndex = 1;
            txtMake.Leave += TxtMakeLeaveEH;
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Location = new Point(13, 218);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(32, 15);
            lblYear.TabIndex = 3;
            lblYear.Text = "Year:";
            // 
            // rdoMotorcycle
            // 
            rdoMotorcycle.AutoSize = true;
            rdoMotorcycle.Location = new Point(80, 30);
            rdoMotorcycle.Name = "rdoMotorcycle";
            rdoMotorcycle.Size = new Size(85, 19);
            rdoMotorcycle.TabIndex = 1;
            rdoMotorcycle.TabStop = true;
            rdoMotorcycle.Text = "Motorcycle";
            rdoMotorcycle.UseVisualStyleBackColor = true;
            rdoMotorcycle.Click += RdoMotorcycleClickEH;
            // 
            // lblModel
            // 
            lblModel.AutoSize = true;
            lblModel.Location = new Point(13, 164);
            lblModel.Name = "lblModel";
            lblModel.Size = new Size(44, 15);
            lblModel.TabIndex = 2;
            lblModel.Text = "Model:";
            // 
            // rdoCar
            // 
            rdoCar.AutoSize = true;
            rdoCar.Location = new Point(13, 30);
            rdoCar.Name = "rdoCar";
            rdoCar.Size = new Size(43, 19);
            rdoCar.TabIndex = 0;
            rdoCar.TabStop = true;
            rdoCar.Text = "Car";
            rdoCar.UseVisualStyleBackColor = true;
            rdoCar.Click += RdoCarClickEH;
            // 
            // lblMake
            // 
            lblMake.AutoSize = true;
            lblMake.Location = new Point(13, 112);
            lblMake.Name = "lblMake";
            lblMake.Size = new Size(39, 15);
            lblMake.TabIndex = 1;
            lblMake.Text = "Make:";
            // 
            // grpSpecialtyProperties
            // 
            grpSpecialtyProperties.Controls.Add(lblSpecialtyDecimalError);
            grpSpecialtyProperties.Controls.Add(txtSpecialtyDecimal);
            grpSpecialtyProperties.Controls.Add(lblSpecialtyDecimal);
            grpSpecialtyProperties.Controls.Add(rdoSpecialtyNo);
            grpSpecialtyProperties.Controls.Add(lblSpecialtyBooleanError);
            grpSpecialtyProperties.Controls.Add(lblSpecialtyBoolean);
            grpSpecialtyProperties.Controls.Add(rdoSpecialtyYes);
            grpSpecialtyProperties.Location = new Point(9, 437);
            grpSpecialtyProperties.Name = "grpSpecialtyProperties";
            grpSpecialtyProperties.Size = new Size(219, 153);
            grpSpecialtyProperties.TabIndex = 1;
            grpSpecialtyProperties.TabStop = false;
            grpSpecialtyProperties.Text = "Specialty Properties";
            // 
            // lblSpecialtyDecimalError
            // 
            lblSpecialtyDecimalError.AutoSize = true;
            lblSpecialtyDecimalError.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSpecialtyDecimalError.ForeColor = Color.Red;
            lblSpecialtyDecimalError.Location = new Point(17, 126);
            lblSpecialtyDecimalError.Name = "lblSpecialtyDecimalError";
            lblSpecialtyDecimalError.Size = new Size(161, 15);
            lblSpecialtyDecimalError.TabIndex = 18;
            lblSpecialtyDecimalError.Text = "Please enter a valid number";
            // 
            // txtSpecialtyDecimal
            // 
            txtSpecialtyDecimal.Location = new Point(113, 100);
            txtSpecialtyDecimal.Name = "txtSpecialtyDecimal";
            txtSpecialtyDecimal.Size = new Size(100, 23);
            txtSpecialtyDecimal.TabIndex = 7;
            // 
            // lblSpecialtyDecimal
            // 
            lblSpecialtyDecimal.AutoSize = true;
            lblSpecialtyDecimal.Location = new Point(6, 108);
            lblSpecialtyDecimal.Name = "lblSpecialtyDecimal";
            lblSpecialtyDecimal.Size = new Size(103, 15);
            lblSpecialtyDecimal.TabIndex = 3;
            lblSpecialtyDecimal.Text = "Specialty Decimal:";
            // 
            // rdoSpecialtyNo
            // 
            rdoSpecialtyNo.AutoSize = true;
            rdoSpecialtyNo.Location = new Point(80, 59);
            rdoSpecialtyNo.Name = "rdoSpecialtyNo";
            rdoSpecialtyNo.Size = new Size(41, 19);
            rdoSpecialtyNo.TabIndex = 5;
            rdoSpecialtyNo.TabStop = true;
            rdoSpecialtyNo.Text = "No";
            rdoSpecialtyNo.UseVisualStyleBackColor = true;
            rdoSpecialtyNo.Click += RdoSpecialtyBooleanClickEH;
            // 
            // lblSpecialtyBooleanError
            // 
            lblSpecialtyBooleanError.AutoSize = true;
            lblSpecialtyBooleanError.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSpecialtyBooleanError.ForeColor = Color.Red;
            lblSpecialtyBooleanError.Location = new Point(9, 82);
            lblSpecialtyBooleanError.Name = "lblSpecialtyBooleanError";
            lblSpecialtyBooleanError.Size = new Size(133, 15);
            lblSpecialtyBooleanError.TabIndex = 15;
            lblSpecialtyBooleanError.Text = "Please select Yes or No";
            // 
            // lblSpecialtyBoolean
            // 
            lblSpecialtyBoolean.AutoSize = true;
            lblSpecialtyBoolean.Location = new Point(12, 41);
            lblSpecialtyBoolean.Name = "lblSpecialtyBoolean";
            lblSpecialtyBoolean.Size = new Size(103, 15);
            lblSpecialtyBoolean.TabIndex = 2;
            lblSpecialtyBoolean.Text = "Specialty Boolean:";
            // 
            // rdoSpecialtyYes
            // 
            rdoSpecialtyYes.AutoSize = true;
            rdoSpecialtyYes.Location = new Point(15, 59);
            rdoSpecialtyYes.Name = "rdoSpecialtyYes";
            rdoSpecialtyYes.Size = new Size(42, 19);
            rdoSpecialtyYes.TabIndex = 4;
            rdoSpecialtyYes.TabStop = true;
            rdoSpecialtyYes.Text = "Yes";
            rdoSpecialtyYes.UseVisualStyleBackColor = true;
            rdoSpecialtyYes.Click += RdoSpecialtyBooleanClickEH;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // grpStoreInventory
            // 
            grpStoreInventory.Controls.Add(lstInventory);
            grpStoreInventory.Location = new Point(273, 22);
            grpStoreInventory.Name = "grpStoreInventory";
            grpStoreInventory.Size = new Size(297, 458);
            grpStoreInventory.TabIndex = 3;
            grpStoreInventory.TabStop = false;
            grpStoreInventory.Text = "Store Inventory";
            // 
            // lstInventory
            // 
            lstInventory.FormattingEnabled = true;
            lstInventory.Location = new Point(17, 27);
            lstInventory.Name = "lstInventory";
            lstInventory.Size = new Size(261, 424);
            lstInventory.TabIndex = 0;
            // 
            // btnAddToCart
            // 
            btnAddToCart.Location = new Point(588, 216);
            btnAddToCart.Name = "btnAddToCart";
            btnAddToCart.Size = new Size(85, 28);
            btnAddToCart.TabIndex = 4;
            btnAddToCart.Text = "Add to Cart";
            btnAddToCart.UseVisualStyleBackColor = true;
            // 
            // grpShoppingCart
            // 
            grpShoppingCart.Controls.Add(lstShoppingCart);
            grpShoppingCart.Location = new Point(708, 22);
            grpShoppingCart.Name = "grpShoppingCart";
            grpShoppingCart.Size = new Size(297, 458);
            grpShoppingCart.TabIndex = 4;
            grpShoppingCart.TabStop = false;
            grpShoppingCart.Text = "Shopping Cart";
            // 
            // lstShoppingCart
            // 
            lstShoppingCart.FormattingEnabled = true;
            lstShoppingCart.Location = new Point(17, 27);
            lstShoppingCart.Name = "lstShoppingCart";
            lstShoppingCart.Size = new Size(261, 424);
            lstShoppingCart.TabIndex = 0;
            // 
            // btnCheckout
            // 
            btnCheckout.Location = new Point(796, 502);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(75, 23);
            btnCheckout.TabIndex = 5;
            btnCheckout.Text = "Checkout";
            btnCheckout.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new Size(61, 4);
            // 
            // Total
            // 
            Total.AutoSize = true;
            Total.Location = new Point(774, 540);
            Total.Name = "Total";
            Total.Size = new Size(36, 15);
            Total.TabIndex = 7;
            Total.Text = "Total:";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(864, 540);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(19, 15);
            lblTotal.TabIndex = 8;
            lblTotal.Text = "$0";
            // 
            // FrmVehicleStore
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1074, 602);
            Controls.Add(lblTotal);
            Controls.Add(Total);
            Controls.Add(btnCheckout);
            Controls.Add(grpShoppingCart);
            Controls.Add(btnAddToCart);
            Controls.Add(grpStoreInventory);
            Controls.Add(grpSpecialtyProperties);
            Controls.Add(grpCreateAVehicle);
            Name = "FrmVehicleStore";
            Text = "Vehicle Store";
            grpCreateAVehicle.ResumeLayout(false);
            grpCreateAVehicle.PerformLayout();
            grpSpecialtyProperties.ResumeLayout(false);
            grpSpecialtyProperties.PerformLayout();
            grpStoreInventory.ResumeLayout(false);
            grpShoppingCart.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpCreateAVehicle;
        private RadioButton rdoVehicle;
        private Label lblPrice;
        private RadioButton rdoPickup;
        private Label lblYear;
        private RadioButton rdoMotorcycle;
        private Label lblModel;
        private RadioButton rdoCar;
        private Label lblMake;
        private Label lblWheels;
        private Button btnCreate;
        private TextBox txtWheels;
        private TextBox txtPrice;
        private TextBox txtYear;
        private TextBox txtModel;
        private TextBox txtMake;
        private GroupBox grpSpecialtyProperties;
        private TextBox txtSpecialtyDecimal;
        private Label lblSpecialtyDecimal;
        private RadioButton rdoSpecialtyNo;
        private Label lblSpecialtyBoolean;
        private RadioButton rdoSpecialtyYes;
        private ContextMenuStrip contextMenuStrip1;
        private GroupBox grpStoreInventory;
        private ListBox lstInventory;
        private Button btnAddToCart;
        private GroupBox grpShoppingCart;
        private ListBox lstShoppingCart;
        private Button btnCheckout;
        private ContextMenuStrip contextMenuStrip2;
        private Label Total;
        private Label lblTotal;
        private Label lblPriceError;
        private Label lblYearError;
        private Label lblWheelsError;
        private Label lblModelError;
        private Label lblMakeError;
        private Label lblVehicleTypeError;
        private Label lblSpecialtyBooleanError;
        private Label lblSpecialtyDecimalError;
    }
}
