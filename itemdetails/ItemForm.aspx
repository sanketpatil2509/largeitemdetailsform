<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemForm.aspx.cs" Inherits="itemdetails.ItemForm" %>


<!doctype html>
<html lang="en">
  <head>
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">

    <title>Hello, world!</title>
      <style>
          form{
              border:groove;
              width:550px;
              height:auto;
              margin:auto;
              padding:30px;
              background-color:antiquewhite;
              
          }
          table,tr,td{
              /*margin:22px;*/
              /*padding:4px;*/
              text-align:left;
              padding-right:0px;
          }
          .tbl1
          {
              width:500px;
              margin:20px;
              
          }
          .form-group.required .control-label:after {
              content:"*";
              color:red;
          }
      </style>
  </head>
  <body><br />
    <form runat="server">

       <div>
           <div style="background-color:darkgray">
           <h3> Add New Menu Item</h3>
               </div>
           
          <table>
              <tr class="form-group required">
                  <td style="width:250px" class="control-label">Section Name:- </td>
                  <td>
                      <asp:DropDownList ID="ddlsectionname" runat="server"  style="width:185px;" AutoPostBack="true" OnSelectedIndexChanged="ddlsectionname_SelectedIndexChanged">
                          <%--<asp:ListItem Text="--Select--"></asp:ListItem>--%>
                      </asp:DropDownList>
                      <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>
                      <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Select the Section Name" ControlToValidate="ddlsectionname" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                  </td>
              </tr>
              <tr class="form-group required">
                <td class="control-label">Counter Name:- </td>
                <td>
                    <asp:DropDownList ID="ddlcountername" runat="server" style="width:185px" AutoPostBack="true" OnSelectedIndexChanged="ddlcountername_SelectedIndexChanged">
                          <%--<asp:ListItem Text="--Select--"></asp:ListItem>--%>
                    </asp:DropDownList>
                      <asp:Label ID="Label2" runat="server" Text="" ForeColor="Red"></asp:Label>

                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Select the Counter Name" ControlToValidate="ddlcountername" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
              <tr class="form-group required">
                <td class="control-label">Category Name:- </td>
                <td>
                    <asp:DropDownList ID="ddlcategoryname" runat="server" style="width:185px">
                      

                        <%--<asp:ListItem Text="--Select--"></asp:ListItem>--%>
                    </asp:DropDownList>
                    <asp:Label ID="Label3" runat="server" Text="" ForeColor="Red"></asp:Label>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Select the Category Name" ControlToValidate="ddlcategoryname" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
              <tr class="form-group required">
                  <td class="control-label">Item Code:-</td>
                  <td>
                      <asp:TextBox ID="txtitemcode" runat="server" Enabled="false"></asp:TextBox>
                      

                      <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please fill Item Code" ControlToValidate="txtitemcode" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                  </td>
              </tr>
              <tr class="form-group required">
                  <td class="control-label">Item Name:-</td>
                  <td>
                      <asp:TextBox ID="txtitemname" runat="server"></asp:TextBox>
                      <asp:Label ID="Label5" runat="server" Text="" ForeColor="Red"></asp:Label>

                      <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please fill the Item Name" ControlToValidate="txtitemname" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                  </td>
              </tr>
              <tr>
                  <td>Item Short Name:-</td>
                  <td>
                      <asp:TextBox ID="txtshort" runat="server"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td>Sale Rate:- </td>
                  <td>
                      <asp:TextBox ID="txtsale" runat="server"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td>Item Disc:-</td>
                  <td>
                      <asp:TextBox ID="txtdisc" runat="server"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td>Disc End Date:-</td>
                  <td>
                      <asp:TextBox ID="txtdiscend" runat="server" Enabled="false"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td>Is Most Used:-</td>
                  <td>
                      <asp:CheckBox ID="chkmostused" runat="server" />
                  </td>
              </tr>
              <%-- <tr>
                  <td><asp:Button ID="btnsave" runat="server" Text="Save"  /></td>
                  <td><asp:Button ID="btncancel" runat="server" Text="Cancel" /></td>
                  <td><asp:Button ID="btnshow" runat="server" Text="Show list" /></td>
    
              </tr>--%>
              
          </table>
           <table class="tbl1">
               
                <tr>
                    <td><asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click"  /></td>
                    <td><asp:Button ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" /></td>
                    <td><asp:Button ID="btncancel" runat="server" Text="Cancel" OnClick="btncancel_Click" /></td>
                    <td><asp:Button ID="btnshow" runat="server" Text="Show list"  OnClick="btnshow_Click"/></td>
    
                </tr>
           </table>
           <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
       </div>
    </form>


    <!-- Optional JavaScript -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.14.7/dist/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
  </body>
</html>