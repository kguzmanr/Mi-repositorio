<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="entrenador.aspx.cs" Inherits="KGFC.entrenador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Entrenadores|KGFC</title>
        <style>
        ul {
          list-style-type: none;
          margin: 0;
          padding: 0;
          overflow: hidden;
          background-color: #333;
        }
        li {
          float: left;
        }
        li a {
          display: block;
          color: white;
          text-align: center;
          padding: 14px 16px;
          text-decoration: none;
        }
        li a:hover {
          background-color: #111;
        }
    </style>
</head>
<body>
    <form id="form2" runat="server">
        <div>
            SISTEMA DE KGFC
        </div>
        <div>
            <ul>
                <li><a class="active" href="principal.aspx">Inicio</a></li>
                <li><a href="jugador.aspx">Jugadores</a></li>
                <li><a href="entrenador.aspx">Entrenadores</a></li>
                <li><a href="#about">Salir</a></li>
            </ul>
        </div>
        <div>
            Código:
            <asp:TextBox ID="tcodigo" runat="server"></asp:TextBox>
            Nombre:
            <asp:TextBox ID="tnombre" runat="server"></asp:TextBox>
            Títulos:
            <asp:TextBox ID="ttitulo" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="sqlentrenador" Height="160px" Width="210px">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                    <asp:BoundField DataField="nombre" HeaderText="nombre" SortExpression="nombre" />
                    <asp:BoundField DataField="titulos" HeaderText="titulos" SortExpression="titulos" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="sqlentrenador" runat="server" ConnectionString="<%$ ConnectionStrings:KGFCConnectionString %>" ProviderName="<%$ ConnectionStrings:KGFCConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [entrenador]"></asp:SqlDataSource>
        </div>
        <div>
            <asp:Button ID="bagregar" runat="server" Text="Agregar" />
            <asp:Button ID="bborrar" runat="server" Text="Borrar" />
            <asp:Button ID="bmodificar" runat="server" Text="Modificar" />
            <asp:Button ID="bconsultar" runat="server" Text="Consultar" />
        </div>
    </form>
</body>
</html>
