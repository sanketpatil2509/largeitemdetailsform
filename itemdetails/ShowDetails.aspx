<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowDetails.aspx.cs" Inherits="itemdetails.ShowDetails" %>

<!doctype html>
<html lang="en">
  <head>
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <!-- Bootstrap CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">

    <title></title>
      
  </head>
  <body>
    
      <form runat="server">
          <h1 style="margin:10px; padding:10px">Item Show Details</h1>
<div class="card-body" style="margin-left:40px">
            <table id="teableid" style="width:auto;margin:20px; border:solid"class="table table-bordered" >
        <thead style="background-color:skyblue">
            <tr>
                <th>Id</th>
                <th>Section Name</th>
                <th>Counter Name</th>
                <th>Category Name</th>
                <th>Item Code</th>
                <th>Item Name</th>
                <th>Item Short Name</th>
                <th>Sale Rate</th>
                <th>Item Disc</th>
                <th>Disc End Date</th>
                <th>Action</th>
            </tr>
        </thead>
        <asp:Repeater ID="savedataID" runat="server" >
            <ItemTemplate>
            <tbody style="background-color:lightcyan">
                <tr>
                     <td><%#Eval("Id") %></td>
                     <td><%#Eval("SectionName") %></td>
                     <td><%#Eval("CounterName") %></td>
                     <td><%#Eval ("CategoryName") %></td>
                     <td><%#Eval("ItemCode") %></td>
                     <td><%#Eval("ItemName") %></td>
                     <td><%#Eval("ItemShortName") %></td>
                     <td><%#Eval("SaleRate") %></td>
                     <td><%#Eval("ItemDiscPerc") %></td>
                     <td><%#Eval("DiscEndDate") %></td>
                    <td>
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" OnClientClick="return confirm('Do you want to delete');">Delete</asp:LinkButton>
                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("Id") %>' Visible="false"></asp:Label>
                    </td>
                    <td><a href="ItemForm.aspx?id=<%#Eval("Id") %>">Edit</a></td>
                  </tr>
                </tbody>
                </ItemTemplate>
    </asp:Repeater>
                </table>
      </form>
    <!-- Optional JavaScript; choose one of the two! -->

    <!-- Option 1: Bootstrap Bundle with Popper -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>

    <!-- Option 2: Separate Popper and Bootstrap JS -->
    
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.2/dist/umd/popper.min.js" integrity="sha384-IQsoLXl5PILFhosVNubq5LC7Qb9DXgDA9i+tQ8Zj3iwWAwPtgFTxbJ8NT4GN1R8p" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.min.js" integrity="sha384-cVKIPhGWiC2Al4u+LWgxfKTRIcfu0JTxR+EQDz/bgldoEyl4H0zUF0QKbrJ0EcQF" crossorigin="anonymous"></script>
    
  </body>
</html>