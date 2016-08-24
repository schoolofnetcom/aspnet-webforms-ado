using Service.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForms.Site.Cliente
{
    public partial class Consultar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            ClienteService srv = new ClienteService();
            //var clienteRetorno = srv.Obter(Convert.ToInt32(txtCodigo.Text));

            //Retornar uma Lista de CLientes
            var lista = srv.Listar(string.Empty);

            gvClientes.DataSource = lista;
            gvClientes.DataBind();
        }

        protected void gvClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName =="Editar")
            {
                int codigo = Convert.ToInt32(e.CommandArgument.ToString());

                Response.Redirect("Cadastrar.aspx?ID=" + codigo);
            }
            if(e.CommandName == "Deletar")
            {
                int codigo = Convert.ToInt32(e.CommandArgument.ToString());
                ClienteService srv = new ClienteService();
                srv.Deletar(codigo);
            }
        }
    }
}