using System;
using BOLAERO;
using BLLAERO;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
/// <summary>
///  Proposal Form (30 May 2018) Rohit Kumar
/// </summary>
public partial class ContactManagement_FrmShopEmployees : System.Web.UI.Page
{
    // Create objects of Classes
    BOLManageShopEmployees ObjBOL = new BOLManageShopEmployees();
    BLLManageShopEmployees ObjBLL = new BLLManageShopEmployees();
    commonclass1 cls = new commonclass1();
    commonclass1 clscon = new commonclass1();
    string folderPath = string.Empty;
    string defval = "0";
    // Page load event
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            GetFilePaths();
            if (!IsPostBack)
            {
                EmptyDT();
                EmptyDTShopEmployeeTraining();
                Bind_Control();
                Bind_Lookup(Convert.ToInt32(defval));
                Bind_GridbyEmployee();
                Bind_DropDownCategory();
            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GetFilePaths()
    {
        try
        {
            folderPath = Utility.ShopEmployeePath();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void CheckBoxLaser()
    {
        try
        {
            if (chkLaser.Checked == true)
            {
                ddlLaser.Enabled = true;
            }
            else
            {
                ddlLaser.Enabled = false;
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    private void CheckBoxBrakePress()
    {
        try
        {
            if (chkbrake.Checked == true)
            {
                ddlbrakepress.Enabled = true;
            }
            else
            {
                ddlbrakepress.Enabled = false;
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    private void CheckBoxWelding()
    {
        try
        {
            if (chkwelding.Checked == true)
            {
                ddlwelding.Enabled = true;
            }
            else
            {
                ddlwelding.Enabled = false;
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    private void CheckBoxPolishing()
    {
        try
        {
            if (chkpolishing.Checked == true)
            {
                ddlpolishing.Enabled = true;
            }
            else
            {
                ddlpolishing.Enabled = false;
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    private void CheckBoxMachineShop()
    {
        try
        {
            if (chkmachineshop.Checked == true)
            {
                ddlMachineShop.Enabled = true;
            }
            else
            {
                ddlMachineShop.Enabled = false;
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    private void CheckBoxElectrical()
    {
        try
        {
            if (chkElectrical.Checked == true)
            {
                ddlElectrical.Enabled = true;
            }
            else
            {
                ddlElectrical.Enabled = false;
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    private void CheckBoxShiping()
    {
        try
        {
            if (chkShippingReceiver.Checked == true)
            {
                ddlShippingandReceiver.Enabled = true;
            }
            else
            {
                ddlShippingandReceiver.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Bind_Control()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetEmployeeInformation(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlPosition, ds.Tables[0]);
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlCountry, ds.Tables[1]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Bind_Lookup(int EmployeeID)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 4;
            ds = ObjBLL.GetEmployeeInformation(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlEmployee, ds.Tables[0]);
                ddlEmployee.SelectedValue = Convert.ToString(EmployeeID);
                if (ddlEmployee.SelectedIndex > 0)
                {
                    btnSave.Text = "Update";
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private Boolean ValidationCheck()
    {
        try
        {
            if (txtFirstName.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter First Name. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter First Name. !");
                txtFirstName.Focus();
                return false;
            }

            if (txtLastName.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Last Name. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Last Name. !");
                txtLastName.Focus();
                return false;
            }

            if (ddlCountry.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Country. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Country. !");
                ddlCountry.Focus();
                return false;
            }

            if (ddlState.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select State. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select State. !");
                ddlState.Focus();
                return false;
            }

            if (ddlPosition.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Position. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Position. !");
                ddlPosition.Focus();
                return false;
            }
            if (ddlStatus.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Status. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Status. !");
                ddlStatus.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    private void GetFilePath()
    {
        try
        {
            hfCusId.Value = String.Empty;
            DataSet ds = new DataSet();
            ObjBOL.Operation = 7;
            ObjBOL.Employeeid = Convert.ToInt32(ddlEmployee.SelectedValue);
            ds = ObjBLL.GetEmployeeInformation(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                hfCusId.Value = ds.Tables[0].Rows[0]["ImagePath"].ToString();
                string Filenamefromdb = ds.Tables[0].Rows[0]["ImagePath"].ToString();
                string[] filename = Filenamefromdb.Split(new char[] { '/' });
                HfFileUpload.Value = filename[2].ToString();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void SaveImage()
    {
        try
        {
            HfSavePath.Value = String.Empty;
            if (!Directory.Exists(folderPath))
            {
                //If Directory (Folder) does not exists Create it.
                Directory.CreateDirectory(folderPath);
            }
            string FileName = txtFirstName.Text + "-" + txtLastName.Text;
            FileInfo currentfile = new FileInfo(FileUpload1.FileName);
            string filenamefromtextbox = FileName;
            string newfilename = filenamefromtextbox + currentfile.Extension;
            HfSavePath.Value = newfilename;
            FileUpload1.SaveAs(folderPath + newfilename);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Savedata()
    {
        try
        {
            if (ValidationCheck() == true)
            {
                string msg = "";
                ObjBOL.FirstName = txtFirstName.Text;
                ObjBOL.LastName = txtLastName.Text;
                ObjBOL.Countryid = Convert.ToInt32(ddlCountry.SelectedValue);
                if (ddlState.SelectedIndex > 0)
                {
                    ObjBOL.Stateid = Convert.ToInt32(ddlState.SelectedValue);
                }
                ObjBOL.City = txtCity.Text;
                ObjBOL.Address = txtAddress.Text;
                ObjBOL.PostalCode = txtPostalCode.Text;
                ObjBOL.Phone = txtPhone.Text;
                ObjBOL.DateHired = Utility.ConvertDate(txtDateHired.Text);
                ObjBOL.Position = Convert.ToInt32(ddlPosition.SelectedValue);
                ObjBOL.Status = Convert.ToInt32(ddlStatus.SelectedValue);
                ObjBOL.EmployeeCurrentStatus = Convert.ToInt32(rdbEmployeeCurrentStatus.SelectedValue);
                ObjBOL.Notes = txtNotes.Text;
                if (FileUpload1.HasFile)
                {
                    SaveImage();
                    ObjBOL.ImagePath = HfSavePath.Value;
                }
                else
                {
                    GetFilePath();
                    ObjBOL.ImagePath = hfCusId.Value;
                }
                ObjBOL.Laser = chkLaser.Checked;
                ObjBOL.LaserType = Convert.ToInt32(ddlLaser.SelectedValue);
                ObjBOL.BrakePress = chkbrake.Checked;
                ObjBOL.BrakePressType = Convert.ToInt32(ddlbrakepress.SelectedValue);
                ObjBOL.Welding = chkwelding.Checked;
                ObjBOL.WeldingType = Convert.ToInt32(ddlwelding.SelectedValue);
                ObjBOL.Polishing = chkpolishing.Checked;
                ObjBOL.PolishingType = Convert.ToInt32(ddlpolishing.SelectedValue);
                ObjBOL.MachineShop = chkmachineshop.Checked;
                ObjBOL.MachineShopType = Convert.ToInt32(ddlMachineShop.SelectedValue);
                ObjBOL.Elecrical = chkElectrical.Checked;
                ObjBOL.ElecricalType = Convert.ToInt32(ddlElectrical.SelectedValue);
                ObjBOL.Shipping = chkShippingReceiver.Checked;
                ObjBOL.ShippingType = Convert.ToInt32(ddlShippingandReceiver.SelectedValue);
                if (btnSave.Text == "Save")
                {
                    ObjBOL.Operation = 2;
                    DataTable dtEmployeeTraining = (DataTable)ViewState["Summary"];
                    DataView dv = new DataView(dtEmployeeTraining);
                    DataTable summarytemp = dv.ToTable("selected", false, "EmployeeDesc", "CategoryID", "Trainer", "TrainingDate");
                    if (dtEmployeeTraining.Rows.Count > 0)
                    {
                        ObjBOL.ShopEmployeeTraining = summarytemp;
                    }
                    else
                    {
                        ObjBOL.ShopEmployeeTraining = (DataTable)summarytemp;
                    }
                    msg = ObjBLL.SaveShopEmployees(ObjBOL);
                    Utility.ShowMessage_Success(this, "Records Added Successfully");

                }
                else if (btnSave.Text == "Update")
                {
                    ObjBOL.Operation = 3;
                    ObjBOL.ShopEmployeeTrainingid = Convert.ToInt32(ddlEmployee.SelectedValue);
                    msg = ObjBLL.UpdateShopEmployees(ObjBOL);
                    Utility.ShowMessage_Success(this, "Records Updated Successfully");
                }
                if (msg != "")
                {
                    defval = msg;
                }
                Bind_Lookup(Convert.ToInt32(defval));
                Bind_GridbyEmployee();
                Bind_DropDownCategory();
                Reset();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Savedata();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private DataTable EmptyDT()
    {
        DataTable dtEmpty = new DataTable();
        try
        {
            dtEmpty.TableName = "ShopEmployeeSummary";
            dtEmpty.Columns.Add(new DataColumn("Shopemployeetrainingid", typeof(int)));
            dtEmpty.Columns.Add(new DataColumn("ShopEmployeeId", typeof(int)));
            dtEmpty.Columns.Add(new DataColumn("EmployeeDesc", typeof(string)));
            dtEmpty.Columns.Add(new DataColumn("CategoryID", typeof(int)));
            dtEmpty.Columns.Add(new DataColumn("CategoryName", typeof(string)));
            dtEmpty.Columns.Add(new DataColumn("Trainer", typeof(string)));
            dtEmpty.Columns.Add(new DataColumn("TrainingDate", typeof(DateTime)));
            DataRow datatRow = dtEmpty.NewRow();
            dtEmpty.Rows.Add(datatRow);//adding row to the datatable         
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dtEmpty;
    }

    private DataTable EmptyDTShopEmployeeTraining()
    {
        DataTable dt = new DataTable();
        try
        {
            //DataRow dr;            
            dt.TableName = "Summary";
            ViewState["Summary"] = null;
            dt.Columns.Add(new DataColumn("Shopemployeetrainingid", typeof(int)));
            dt.Columns.Add(new DataColumn("ShopEmployeeId", typeof(int)));
            dt.Columns.Add(new DataColumn("EmployeeDesc", typeof(string)));
            dt.Columns.Add(new DataColumn("CategoryID", typeof(int)));
            dt.Columns.Add(new DataColumn("CategoryName", typeof(string)));
            dt.Columns.Add(new DataColumn("Trainer", typeof(string)));
            dt.Columns.Add(new DataColumn("TrainingDate", typeof(DateTime)));
            ViewState["Summary"] = dt;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void BindTrainingDetailsTemp(DataTable dt)
    {
        try
        {
            DataTable dtSummary = dt;
            if (dtSummary.Rows.Count > 0)
            {
                gvShopEmployee.DataSource = dtSummary;
                gvShopEmployee.DataBind();
            }
            else
            {
                gvShopEmployee.DataSource = EmptyDT();
                gvShopEmployee.DataBind();
                gvShopEmployee.Rows[0].Visible = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Bind_GridbyEmployee()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 6;
            if (ddlEmployee.SelectedIndex > 0)
            {
                ObjBOL.Employeeid = Convert.ToInt32(ddlEmployee.SelectedValue);
                ds = ObjBLL.GetEmployeeInformation(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    ViewState["Summary"] = dt;
                    BindTrainingDetailsTemp(dt);
                }
                else
                {
                    gvShopEmployee.DataSource = EmptyDT();
                    gvShopEmployee.DataBind();
                    gvShopEmployee.Rows[0].Visible = false;
                }
            }
            else
            {
                gvShopEmployee.DataSource = EmptyDT();
                gvShopEmployee.DataBind();
                gvShopEmployee.Rows[0].Visible = false;
            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Bind_DropDownCategory()
    {
        try
        {
            DropDownList Categoryid = (gvShopEmployee.FooterRow.FindControl("ddlFooterCategory") as DropDownList);
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetEmployeeInformation(ObjBOL);
            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownList(Categoryid, ds.Tables[2]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Reset()
    {
        try
        {
            if (ddlEmployee.SelectedIndex > 0)
            {
                ddlEmployee.SelectedIndex = 0;
            }
            txtFirstName.Text = String.Empty;
            txtLastName.Text = String.Empty;
            txtAddress.Text = String.Empty;
            txtDateHired.Text = String.Empty;
            ddlCountry.SelectedIndex = 0;
            if (ddlState.SelectedIndex > 0)
            {
                ddlState.DataSource = "";
                ddlState.DataBind();
            }
            txtCity.Text = String.Empty;
            txtPostalCode.Text = String.Empty;
            txtPhone.Text = String.Empty;
            ddlPosition.SelectedIndex = 0;
            ddlStatus.SelectedIndex = 0;
            txtNotes.Text = String.Empty;
            chkLaser.Checked = false;
            CheckBoxLaser();
            chkbrake.Checked = false;
            CheckBoxBrakePress();
            chkwelding.Checked = false;
            CheckBoxWelding();
            chkpolishing.Checked = false;
            CheckBoxPolishing();
            chkmachineshop.Checked = false;
            CheckBoxMachineShop();
            chkElectrical.Checked = false;
            CheckBoxElectrical();
            chkShippingReceiver.Checked = false;
            CheckBoxShiping();
            ddlLaser.SelectedIndex = 0;
            ddlbrakepress.SelectedIndex = 0;
            ddlwelding.SelectedIndex = 0;
            ddlpolishing.SelectedIndex = 0;
            ddlMachineShop.SelectedIndex = 0;
            ddlElectrical.SelectedIndex = 0;
            ddlShippingandReceiver.SelectedIndex = 0;
            gvShopEmployee.DataSource = EmptyDT();
            gvShopEmployee.DataBind();
            gvShopEmployee.Rows[0].Visible = false;
            btnSave.Text = "Save";
            Image1.ImageUrl = String.Empty;
            Bind_DropDownCategory();
            EmptyDTShopEmployeeTraining();
            rdbEmployeeCurrentStatus.SelectedValue = "1";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ViewState["Summary"] = null;
            DataSet ds = new DataSet();
            ObjBOL.Operation = 5;
            ObjBOL.Employeeid = Convert.ToInt32(ddlEmployee.SelectedValue);
            ds = ObjBLL.GetEmployeeInformation(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //Image1.ImageUrl = String.Empty;
                txtFirstName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
                txtLastName.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
                txtAddress.Text = ds.Tables[0].Rows[0]["EmployeeAdd"].ToString();
                ddlCountry.SelectedValue = ds.Tables[0].Rows[0]["countryid"].ToString();
                BindState(ddlCountry.SelectedValue);
                ddlState.SelectedValue = ds.Tables[0].Rows[0]["stateid"].ToString();
                txtCity.Text = ds.Tables[0].Rows[0]["city"].ToString();
                txtPostalCode.Text = ds.Tables[0].Rows[0]["postalcode"].ToString();
                txtPhone.Text = ds.Tables[0].Rows[0]["phone"].ToString();
                txtDateHired.Text = cls.Converter(ds.Tables[0].Rows[0]["DateHired"].ToString());
                ddlPosition.SelectedValue = ds.Tables[0].Rows[0]["Position"].ToString();
                ddlStatus.SelectedValue = ds.Tables[0].Rows[0]["EmployeeStatus"].ToString();
                rdbEmployeeCurrentStatus.SelectedValue = ds.Tables[0].Rows[0]["employeecurrentstatus"].ToString();
                txtNotes.Text = ds.Tables[0].Rows[0]["Notes"].ToString();
                //GetFilePath();
                //FileInfo currentfile = new FileInfo(HfFileUpload.Value);             
                //string newfilename = currentfile + currentfile.Extension;
                FileInfo file = new FileInfo(folderPath + ds.Tables[0].Rows[0]["ImagePath"].ToString());
                if (file.Exists)
                {
                    Image1.ImageUrl = "../ImageHandler.ashx?imagePath=" + folderPath + ds.Tables[0].Rows[0]["ImagePath"].ToString();
                }
                else
                {
                    Image1.ImageUrl = string.Empty;
                }
                chkLaser.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Laser"].ToString());
                CheckBoxLaser();
                ddlLaser.SelectedValue = ds.Tables[0].Rows[0]["LaserType"].ToString();
                chkbrake.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["BrakePress"].ToString());
                CheckBoxBrakePress();
                ddlbrakepress.SelectedValue = ds.Tables[0].Rows[0]["BrakePressType"].ToString();
                chkwelding.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Welding"].ToString());
                CheckBoxWelding();
                ddlwelding.SelectedValue = ds.Tables[0].Rows[0]["WeldingType"].ToString();
                chkpolishing.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Polishing"].ToString());
                CheckBoxPolishing();
                ddlpolishing.SelectedValue = ds.Tables[0].Rows[0]["PolishingType"].ToString();
                chkmachineshop.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["MachineShop"].ToString());
                CheckBoxMachineShop();
                ddlMachineShop.SelectedValue = ds.Tables[0].Rows[0]["MachineShopType"].ToString();
                chkElectrical.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Elecrical"].ToString());
                CheckBoxElectrical();
                ddlElectrical.SelectedValue = ds.Tables[0].Rows[0]["ElecricalType"].ToString();
                chkShippingReceiver.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Shipping"].ToString());
                CheckBoxShiping();
                ddlShippingandReceiver.SelectedValue = ds.Tables[0].Rows[0]["ShippingType"].ToString();
                Bind_GridbyEmployee();
                Bind_DropDownCategory();
                btnSave.Text = "Update";
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void PrepareDT(int Shopemployeetrainingid, string Desc, int Categoryid, string CategoryName, string Trainer, DateTime date)
    {
        try
        {
            DataTable dtCurrentTable = (DataTable)ViewState["Summary"];
            DataRow drCurrentRow = null;
            drCurrentRow = dtCurrentTable.NewRow();
            drCurrentRow["Shopemployeetrainingid"] = Shopemployeetrainingid;
            drCurrentRow["EmployeeDesc"] = Desc;
            drCurrentRow["CategoryID"] = Categoryid;
            drCurrentRow["CategoryName"] = CategoryName;
            drCurrentRow["Trainer"] = Trainer;
            drCurrentRow["TrainingDate"] = date;
            dtCurrentTable.AcceptChanges();
            dtCurrentTable.Rows.Add(drCurrentRow);
            DataTable dt = (DataTable)ViewState["Summary"];
            BindTrainingDetailsTemp(dtCurrentTable);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private Boolean ValidationCheckEmployeeTraining()
    {
        try
        {
            TextBox description = (gvShopEmployee.FooterRow.FindControl("txtFooterDesc") as TextBox);
            DropDownList Categoryid = (gvShopEmployee.FooterRow.FindControl("ddlFooterCategory") as DropDownList);
            if (description.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Description. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Description. !");
                description.Focus();
                return false;
            }
            if (Categoryid.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Category. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Category. !");
                Categoryid.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    private void EmployeeTrainingAdd()
    {
        try
        {
            if (txtFirstName.Text != "")
            {
                string msg = "";
                string description = (gvShopEmployee.FooterRow.FindControl("txtFooterDesc") as TextBox).Text;
                string Categoryid = (gvShopEmployee.FooterRow.FindControl("ddlFooterCategory") as DropDownList).SelectedValue;
                string CategoryName = (gvShopEmployee.FooterRow.FindControl("ddlFooterCategory") as DropDownList).SelectedItem.Text;
                string Trainer = (gvShopEmployee.FooterRow.FindControl("txtFooterTrainer") as TextBox).Text;
                DateTime Date = Convert.ToDateTime((gvShopEmployee.FooterRow.FindControl("txtFooterDate") as TextBox).Text);
                if (btnSave.Text == "Save")
                {
                    PrepareDT(0, description, Convert.ToInt32(Categoryid), CategoryName, Trainer, Date);
                    Bind_DropDownCategory();
                }
                else if (btnSave.Text == "Update")
                {
                    ObjBOL.Operation = 8;
                    ObjBOL.ShopEmployeeTrainingid = Convert.ToInt32(ddlEmployee.SelectedValue);
                    ObjBOL.Description = description;
                    ObjBOL.Categoryid = Convert.ToInt32(Categoryid);
                    ObjBOL.Trainer = Trainer;
                    ObjBOL.TrainingDate = Date;
                    msg = ObjBLL.BLLAddShopEmployeeTraining(ObjBOL);
                    Bind_GridbyEmployee();
                    Bind_DropDownCategory();
                }
            }
            else
            {
                Utility.ShowMessage_Error(this, "Please Enter Employee Basic Details First !!!");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            EmployeeTrainingAdd();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvShopEmployee_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            gvShopEmployee.EditIndex = e.NewEditIndex;
            Bind_GridbyEmployee();
            Bind_DropDownCategory();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvShopEmployee_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList CategoryidEdit = (e.Row.FindControl("ddlCategory") as DropDownList);
                if(CategoryidEdit != null)
                {
                    Label CategoryidEditlabel = (e.Row.FindControl("lblCategoryEdit") as Label);
                    ObjBOL.Operation = 1;
                    ds = ObjBLL.GetEmployeeInformation(ObjBOL);
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        Utility.BindDropDownList(CategoryidEdit, ds.Tables[2]);
                        CategoryidEdit.SelectedValue = CategoryidEditlabel.Text;
                    }
                }
                
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvShopEmployee_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            gvShopEmployee.EditIndex = -1;
            Bind_GridbyEmployee();
            Bind_DropDownCategory();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            Reset();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvShopEmployee_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            string msg = "";
            int ID = Convert.ToInt32(gvShopEmployee.DataKeys[e.RowIndex].Value);
            ObjBOL.Operation = 9;
            ObjBOL.Employeeid = ID;
            GridViewRow row = gvShopEmployee.Rows[e.RowIndex];
            int rowid = row.RowIndex;
            TextBox txtDesc = row.FindControl("txtDesc") as TextBox;
            DropDownList ddlCategory = row.FindControl("ddlCategory") as DropDownList;
            TextBox txtTrainer = row.FindControl("txtTrainer") as TextBox;
            TextBox txtDate = row.FindControl("txtDate") as TextBox;
            ObjBOL.ShopEmployeeTrainingid = Convert.ToInt32(ddlEmployee.SelectedValue);
            ObjBOL.Description = txtDesc.Text;
            ObjBOL.Categoryid = Convert.ToInt32(ddlCategory.SelectedValue);
            ObjBOL.Trainer = txtTrainer.Text;
            ObjBOL.TrainingDate = Utility.ConvertDate(txtDate.Text);
            msg = ObjBLL.BLLAddShopEmployeeTraining(ObjBOL);
            gvShopEmployee.EditIndex = -1;
            Bind_GridbyEmployee();
            Bind_DropDownCategory();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindState(string Countryid)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 10;
            ObjBOL.Countryid = Convert.ToInt32(Countryid);
            ds = ObjBLL.GetEmployeeInformation(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlState, ds.Tables[0]);
            }
            else
            {
                ddlState.DataSource = "";
                ddlState.DataBind();
                ddlState.Items.Insert(0, new ListItem("Select", "0"));
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindState(ddlCountry.SelectedValue);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}