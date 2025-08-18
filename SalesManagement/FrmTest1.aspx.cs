using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

public class DriveUnitClass
{
    public string Conveyor { get; set; }
    public string ConveyorType { get; set; }
    public string DriveUnit { get; set; }
    public string Qty { get; set; }
    public string Action { get; set; }
}

public class ConveyorType
{
    public int id { get; set; }
    public string text { get; set; }
}

public partial class Test1_FrmTest : System.Web.UI.Page
{
    List<DriveUnitClass> data = new List<DriveUnitClass>
    {
        new DriveUnitClass() { Conveyor = "TAC", ConveyorType = "Standard TAC", DriveUnit = "0026100 Tray Accumulator, (10X 4 Tier)", Qty="2", Action = "Edit/Delete" },
        new DriveUnitClass() { Conveyor = "TAC", ConveyorType = "Rectangular TAC", DriveUnit = "0022301 - LADDER (4\"x6 3/4\")", Qty="3", Action = "Edit/Delete" }
    };

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gvTest.DataSource = data;
            gvTest.DataBind();
        }
    }

    protected void ddlConveyorType_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSize.DataSource = string.Empty;
        ddlSize.DataBind();
        gvTemp.DataSource = string.Empty;
        gvTemp.DataBind();
        List<ConveyorType> obj = new List<ConveyorType>();
        if (ddlConveyorType.SelectedValue == "5" || ddlConveyorType.SelectedValue == "6" || ddlConveyorType.SelectedValue == "7")
        {
            obj.Add(new ConveyorType() { id = 0, text = "Select" });
            obj.Add(new ConveyorType() { id = 1, text = "Drive Unit" });
            obj.Add(new ConveyorType() { id = 2, text = "Tail Tank" });
            obj.Add(new ConveyorType() { id = 3, text = "Curve" });
            obj.Add(new ConveyorType() { id = 4, text = "End opening corner" });
            obj.Add(new ConveyorType() { id = 5, text = "Slat belt chain length" });
            obj.Add(new ConveyorType() { id = 6, text = "Bed support bracket" });
        }
        else if (ddlConveyorType.SelectedValue == "1")
        {
            obj.Add(new ConveyorType() { id = 0, text = "Select" });
            obj.Add(new ConveyorType() { id = 11, text = "0026100 Tray Accumulator, (10X 4 Tier)" });
            obj.Add(new ConveyorType() { id = 12, text = "0026300 Tray Accumulator, (12 X 4 Tier)" });
            obj.Add(new ConveyorType() { id = 13, text = "0026500 Tray Accumulator, (14 X 4 Tier)" });
            obj.Add(new ConveyorType() { id = 14, text = "0026700 Tray Accumulator, (16 X 4 Tier)" });
        }
        else if (ddlConveyorType.SelectedValue == "2" || ddlConveyorType.SelectedValue == "3")
        {
            obj.Add(new ConveyorType() { id = 0, text = "Select" });
            obj.Add(new ConveyorType() { id = 21, text = "0022301 ‐ LADDER(4\"x6 3 / 4\")" });
            obj.Add(new ConveyorType() { id = 22, text = "CARRIER" });
        }
        else if (ddlConveyorType.SelectedValue == "4")
        {
            obj.Add(new ConveyorType() { id = 0, text = "Select" });
            obj.Add(new ConveyorType() { id = 31, text = "15\" PITCH" });
            obj.Add(new ConveyorType() { id = 32, text = "21\" PITCH" });
        }

        ddlSize.DataSource = obj;
        ddlSize.DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        var driveUnits = gvTemp.Rows.Cast<GridViewRow>()
         .Where(row => ((TextBox)row.FindControl("txtQty")).Text.Trim() != "")
         .Select(row => new DriveUnitClass
         {
             Conveyor = ddlConveyorModel.SelectedItem.Text,
             ConveyorType = ddlConveyorType.SelectedItem.Text,
             DriveUnit = ((Label)row.FindControl("partno")).Text,
             Qty = ((TextBox)row.FindControl("txtQty")).Text,
             Action = "Edit/Delete"
         })
         .ToList<DriveUnitClass>();

        data.AddRange(driveUnits);

        gvTest.DataSource = data;
        gvTest.DataBind();
    }

    protected void ddlConveyorModel_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlConveyorType.DataSource = string.Empty;
        ddlConveyorType.DataBind();
        ddlSize.DataSource = string.Empty;
        ddlSize.DataBind();
        gvTemp.DataSource = string.Empty;
        gvTemp.DataBind();

        List<ConveyorType> obj = new List<ConveyorType>();
        if (ddlConveyorModel.SelectedValue == "SBC")
        {
            obj.Add(new ConveyorType() { id = 0, text = "Select" });
            //obj.Add(new ConveyorType() { id = 5, text = "Single" });
            obj.Add(new ConveyorType() { id = 5, text = "Single 7\"" });
            obj.Add(new ConveyorType() { id = 6, text = "Single 10\"" });
            obj.Add(new ConveyorType() { id = 7, text = "Single 12\"" });
            obj.Add(new ConveyorType() { id = 8, text = "Double" });
            ddlConveyorType.DataSource = obj;
            ddlConveyorType.DataBind();
            //ddlConveyorType.SelectedValue = "6";
        }
        else if (ddlConveyorModel.SelectedValue == "TAC")
        {
            obj.Add(new ConveyorType() { id = 0, text = "Select" });
            obj.Add(new ConveyorType() { id = 1, text = "Standard TAC" });
            obj.Add(new ConveyorType() { id = 2, text = "Rectangular TAC" });
            obj.Add(new ConveyorType() { id = 3, text = "Traingular TAC" });
            obj.Add(new ConveyorType() { id = 4, text = "Custom TAC" });
            ddlConveyorType.DataSource = obj;
            ddlConveyorType.DataBind();
            //ddlConveyorType.SelectedValue = "6";
        }

        
    }

    protected void ddlSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSize.SelectedIndex > 0)
        {
            List<object> obj = new List<object>();
            if (ddlSize.SelectedValue == "1")
            {
                if (ddlConveyorType.SelectedValue == "6")
                {
                    obj.Add(new { part = "0010001 , E - Std Drive Unit (Single(10) L-R)" });
                    obj.Add(new { part = "0010002 , E - Std Drive Unit (Single(10) R-L)" });
                }
                else if (ddlConveyorType.SelectedValue == "7")
                {
                    obj.Add(new { part = "0010005 , E - Std Drive Unit (Single(12) L-R)" });
                    obj.Add(new { part = "0010006 , E - Std Drive Unit (Single(12) R-L)" });
                }
                else if (ddlConveyorType.SelectedValue == "8")
                {
                    obj.Add(new { part = "0010003 , E - Std Drive Unit (Dual - L-R)" });
                    obj.Add(new { part = "0010004 , E - Std Drive Unit (Dual - R-L))" });
                }
                obj.Add(new { part = "0012139 , Drive Unit Door (26 H) Assy." });
                obj.Add(new { part = "0010011 , DOORLESS DRIVE UNIT (SINGLE (10) R-L)" });
                obj.Add(new { part = "0010012 , DOORLESS DRIVE UNIT (SINGLE (10) L-R)" });
            }
            else if (ddlSize.SelectedValue == "2")
            {
                if (ddlConveyorType.SelectedValue == "6")
                {
                    obj.Add(new { part = "0210021 , B Tail Tank Assy (10\" - Front Belt)" });
                    obj.Add(new { part = "0210610 , B Tail Tank Assy (10\" Belt)" });
                    obj.Add(new { part = "0210640 , B Tail Tank Assy (10\" - Rear Belt)" });
                }
                else if (ddlConveyorType.SelectedValue == "8")
                {
                    obj.Add(new { part = "0210071 , B Tail Tank Assy (Dual Belt - Front)" });
                    obj.Add(new { part = "0210630 , B Tail Tank Assy (Dual Belt)" });
                }
            }
            else if (ddlSize.SelectedValue == "3")
            {
                if (ddlConveyorType.SelectedValue == "5")
                {
                    //obj.Add(new { part = "0213001 , G - Single 90 Deg Retrun Track Assembly" });
                    //obj.Add(new { part = "0213003 , E Single 45 Return Track Assembly" });
                }
                else if (ddlConveyorType.SelectedValue == "6")
                {
                    //obj.Add(new { part = "0213001 , G - Single 90 Deg Retrun Track Assembly" });
                    //obj.Add(new { part = "0213003 , E Single 45 Return Track Assembly" });
                }
                else if (ddlConveyorType.SelectedValue == "7")
                {
                    //obj.Add(new { part = "0213001 , G - Single 90 Deg Retrun Track Assembly" });
                   // obj.Add(new { part = "0213003 , E Single 45 Return Track Assembly" });
                    obj.Add(new { part = "0213310 , A Single 90 Deg Retrun Track Assembly (12\")" });
                }
                else if (ddlConveyorType.SelectedValue == "8")
                {
                    obj.Add(new { part = "0213002 , H - Dual 90 Return Track Assembly" });
                    obj.Add(new { part = "0213004 , E Dual 45 Return Track Assembly" });
                    obj.Add(new { part = "0213008 , D Dual 60 Return Track Assembly" });
                }
                obj.Add(new { part = "0214161 , A Sbc Curve, Single 90 Mid Assy" });
                obj.Add(new { part = "0214162 , A Sbc Curve, Dual 90 Mid Assy" });
                obj.Add(new { part = "214402 ,  S 45, Mid Plate Assy" });
                obj.Add(new { part = "214403 ,  S 60 Turn, Mid Plate Assy" });
                obj.Add(new { part = "214407 ,  D 45 Turn Mid Plate Assy" });
                obj.Add(new { part = "214408 ,  D 60, Mid Plate Assy" });
            }
            else if (ddlSize.SelectedValue == "4")
            {
                //obj.Add(new { part = "0214500 End Opening Cover Assy" });
            }
            else if (ddlSize.SelectedValue == "5")
            {
                if (ddlConveyorType.SelectedValue == "6")
                {
                    obj.Add(new { part = "0214003 , B Slat Belt Mounting Tool (10\")" });
                    obj.Add(new { part = "8117401 , Chain 63Sb Ss Chain (Sbc)" });
                    obj.Add(new { part = "8117403 , Slat Belt Chain Length (Drive Chain #50 Ss)" });
                }
            }
            else if (ddlSize.SelectedValue == "6")
            {
                obj.Add(new { part = "0214011 , B Sbc Bed Support Bracket (Single, L=14\")" });
                obj.Add(new { part = "0214013 , A Sbc Bed Support Bracket (D, 25\")" });
            }
            else if (ddlSize.SelectedValue == "11")
            {
                obj.Add(new { part = "0023520 ‐ PLATE CARRIER (12\"X16\")" });
                obj.Add(new { part = "0023100 ‐ WIRE CARRIER (14\"x18\")" });
                obj.Add(new { part = "0023140 ‐ WIRE CARRIER (18\"x14\")" });
            }
            else if (ddlSize.SelectedValue == "12")
            {
                obj.Add(new { part = "0026300 Tray Accumulator, (12 X 4 Tier)" });
            }
            else if (ddlSize.SelectedValue == "13")
            {
                obj.Add(new { part = "0026500 Tray Accumulator, (14 X 4 Tier)" });
            }
            else if (ddlSize.SelectedValue == "14")
            {
                obj.Add(new { part = "0026700 Tray Accumulator, (16 X 4 Tier)" });
            }
            else if (ddlSize.SelectedValue == "21")
            {
                obj.Add(new { part = "0022301 ‐ LADDER(4\"x6 3 / 4\")" });
            }
            else if (ddlSize.SelectedValue == "22" || ddlSize.SelectedValue == "31")
            {
                //obj.Add(new { part = "0022301 ‐ LADDER(4\"x6 3 / 4\")" });
                obj.Add(new { part = "0023520 ‐ PLATE CARRIER (12\"X16\")" });
                obj.Add(new { part = "0023100 ‐ WIRE CARRIER (14\"x18\")" });
                obj.Add(new { part = "0023140 ‐ WIRE CARRIER (18\"x14\")" });
            }

            gvTemp.DataSource = obj;
            gvTemp.DataBind();
        }
        else
        {
            gvTemp.DataSource = string.Empty;
            gvTemp.DataBind();
        }
    }
}