<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="principal.aspx.cs" Inherits="KGFC.principal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>KGFC</title>
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
    <form id="form1" runat="server">
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
        </div>
    </form>
</body>
</html>
