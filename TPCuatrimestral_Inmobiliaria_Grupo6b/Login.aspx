<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPCuatrimestral_Inmobiliaria_Grupo6b.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.6/dist/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="customize.css" <%-- linkea a la clase para el formato borde sombreado del contenedor del form  --%>
</head>
<body>
    <form id="form1" runat="server">
        <div class="d-flex justify-content-center align-items-center" style="height: 100vh;">
            <div align="center" class="container bg-light boxshadow" style="width:35%; border-radius: 15px; padding: 0;">

                <form>
                    <div class="card-header-pills bg-dark text-white rounded-top d-flex align-items-center justify-content-center">
                        <h2>Login</h2>
                    </div>
                    <br />
                    <div class="form-group" style="width:80%">
                        <label class="text-dark" for="emailLabel">Correo Electronico</label>
                        <div class="input-group mb-2">
                            <div class="input-group-prepend">
                                <div class="input-group-text">@</div>
                            </div>
                            <asp:TextBox ID="TextBoxCorreo" runat="server" CssClass="form-control" placeholder="Ingrese su correo" Width="90%"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="text-dark" for="contraLabel">Contraseña</label>
                        <asp:TextBox ID="TextBoxContra" runat="server" CssClass="form-control" placeholder="Ingrese su contraseña" Width="80%"></asp:TextBox>
                    </div>
                    <div class="form-group" align="center">   
                        <asp:LinkButton ID="LinkButtonRecordarContra" runat="server" CssClass="btn btn-link" style="font-size: 12px;">¿Olvidó contraseña?</asp:LinkButton>
                    </div>
                    <div class="form-group" align="center">   
                        <asp:LinkButton ID="LinkButtonSinCuenta" runat="server" CssClass="btn btn-link" style="font-size: 12px;">¿Registrarse?</asp:LinkButton>
                    </div>

                    <br>

<%--   Boton de recordarme (pendiente, si llego lo agrego)    
                    <div class="form-group form-check">
                        <label class="form-check-label" for="passLabel">Recordarme?</label>
                        <asp:CheckBox ID="CheckBoxRecordar" runat="server" CssClass="form-check-input" />
                    </div>--%>
                    <asp:Button ID="ButtonIngresar" runat="server" Text="Ingresar" CssClass="btn btn-primary" BackColor="Black" style="margin-bottom: 20px;" />
                    <br>
                </form>
            </div>
        </div>
    </form>
</body>
</html>