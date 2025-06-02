<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="TPCuatrimestral_Inmobiliaria_Grupo6b.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.6/dist/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="customize.css" <%-- linkea a la clase para el formato borde sombreado del contenedor del form  --%>
</head>
<body>
    <form id="form1" runat="server">
        <div class="d-flex justify-content-center align-items-center" style="min-height: 100vh; padding: 10px 0;">
            <div align="center" class="container bg-light boxshadow" style="width:50%; border-radius: 15px; padding: 0;">
                
                <form>
                    <div class="bg-dark text-white d-flex align-items-center justify-content-center" style="border-top-left-radius: 15px; border-top-right-radius: 15px; padding: 5px 0; margin: 0;">
                        <h5>Registro de usuario</h5>
                    </div>
                    
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
                        <label class="text-dark" for="contrasenaLabel">Contraseña</label>
                        <asp:TextBox ID="TextBoxContra" runat="server" CssClass="form-control" placeholder="Alfanúmerico todo minúscula" Width="80%"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label class="text-dark" for="nombreLabel">Nombre</label>
                        <asp:TextBox ID="TextBoxNombre" runat="server" CssClass="form-control" placeholder="Ingrese su nombre" Width="80%"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label class="text-dark" for="apellidoLabel">Apellido</label>
                        <asp:TextBox ID="TextBoxApellido" runat="server" CssClass="form-control" placeholder="Ingrese su apellido" Width="80%"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label class="text-dark" for="telefonoLabel">Teléfono</label>
                        <asp:TextBox ID="TextBoxTelefono" runat="server" CssClass="form-control" placeholder="Solo números sin espacios" Width="80%"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label class="text-dark" for="direccionLabel">Dirección</label>
                        <asp:TextBox ID="TextBoxDireccion" runat="server" CssClass="form-control" placeholder="Calle y N°" Width="80%"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label class="text-dark" for="localidadLabel">Localidad</label>
                        <asp:TextBox ID="TextBoxLocalidad" runat="server" CssClass="form-control" placeholder="Localidad" Width="80%"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label class="text-dark" for="provinciaLabel">Selecciona provincia</label>
                        <asp:DropDownList ID="DropDownListProvincia" runat="server" CssClass="form-control" Width="80%"></asp:DropDownList>
                    </div>
                    
                    <div class="form-group">
                        <label class="text-dark" for="rolLabel">Tipo de usuario</label>
                        <asp:DropDownList ID="DropDownListRol" runat="server" CssClass="form-control" Width="80%"></asp:DropDownList>
                    </div>

                    
                    <asp:Button ID="ButtonRegistrar" runat="server" Text="Resgistrar" CssClass="btn btn-primary" BackColor="Black" style="margin-bottom: 20px;" />
                    
                </form>
            </div>
        </div>
    </form>
</body>
</html>