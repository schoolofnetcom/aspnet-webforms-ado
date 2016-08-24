using Domain.Entities;
using Repository.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Impl
{
    public class ClienteService
    {
        ClienteRepository repo = new ClienteRepository();

        //CRUD
        public void Salvar(Cliente cliente)
        {
            repo.Save(cliente);
        }

        public Cliente Obter(int codigo)
        {
            return repo.Get(codigo);
        }

        public List<Cliente> Listar(string nome)
        {
            return repo.List(nome);
        }

        public void Deletar(int codigo)
        {
            repo.Delete(codigo);
        }
    }
}
