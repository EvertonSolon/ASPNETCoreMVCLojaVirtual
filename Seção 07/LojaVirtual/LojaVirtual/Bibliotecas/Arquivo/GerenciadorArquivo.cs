using LojaVirtual.Bibliotecas.Bug;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Bibliotecas.Arquivo
{
    public class GerenciadorArquivo
    {
        public static string CadastrarImagemProduto(IFormFile file)
        {
            CurrentDirectoryHelpers.SetCurrentDirectory();
            var nomeArquivo = Path.GetFileName(file.FileName);
            var caminho = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/temp", nomeArquivo);

            using(var stream = new FileStream(caminho, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return Path.Combine("/uploads/temp", nomeArquivo).Replace("\\", "/");
        }

        public static bool ExcluirImagemProduto(string caminho_)
        {
            var caminho = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", caminho_.TrimStart('/'));
            var existe = File.Exists(caminho);

            if (existe)
                File.Delete(caminho);

            return existe;
        }
    }
}
