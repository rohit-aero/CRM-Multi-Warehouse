using System;
using System.Collections.Generic;

public partial class Test_FrmTest : System.Web.UI.Page
{
    object data = new List<object>
    {
        new  { Conveyor = "SBC", ConveyorType = "Single 7\"", DriveUnit = "010001 L-R", Action = "Edit/Delete" },
        new  { Conveyor = "SBC", ConveyorType = "Single 10\"", DriveUnit = "010002 L-R", Action = "Edit/Delete" }
    };

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gvTest.DataSource = data;
            gvTest.DataBind();
        }
    }

    protected void ddlConveyorModel_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlConveyorModel.SelectedIndex > 0)
        {
            type.Visible = true;
        }
        else
        {
            type.Visible = false;
            driveunit.Visible = false;
            ddlConveyorType.SelectedIndex = 0;
            ddlDriveUnit.SelectedIndex = 0;
        }
    }

    protected void ddlConveyorType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlConveyorType.SelectedIndex > 0)
        {
            driveunit.Visible = true;
        }
        else
        {
            driveunit.Visible = false;
            ddlDriveUnit.SelectedIndex = 0;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (!chkModelPersistent.Checked)
        {
            type.Visible = false;
            driveunit.Visible = false;
            ddlConveyorModel.SelectedIndex = 0;
        }
        ddlDriveUnit.SelectedIndex = 0;
        txtQty.Text = "";
    }
}