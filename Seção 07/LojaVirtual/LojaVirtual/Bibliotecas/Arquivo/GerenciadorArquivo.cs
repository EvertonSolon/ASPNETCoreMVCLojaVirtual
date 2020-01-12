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

        internal static List<string> MoverImagensProduto(List<string> listaCaminhosImagensTemporarias, string produtoId)
        {
            var caminhoDefinitivoPastaProduto = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", produtoId);
            var directorioExiste = Directory.Exists(caminhoDefinitivoPastaProduto);

            if (!directorioExiste)
                Directory.CreateDirectory(caminhoDefinitivoPastaProduto);

            var listaCaminhosDefinitivos = new List<string>();

            foreach (var caminhoImagemTemporaria in listaCaminhosImagensTemporarias)
            {
                if(string.IsNullOrEmpty(caminhoImagemTemporaria))
                {
                    var nomeArquivo = Path.GetFileName(caminhoImagemTemporaria);

                    var caminhoAbsolutoImagemTemporaria = Path.Combine(Directory.GetCurrentDirectory(),
                        "wwwroot", caminhoImagemTemporaria);

                    var caminhoAbsolutoDefinitio = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads",
                        produtoId, nomeArquivo);

                    if (File.Exists(caminhoAbsolutoImagemTemporaria))
                    {
                        File.Copy(caminhoAbsolutoImagemTemporaria, caminhoAbsolutoDefinitio);

                        if (File.Exists(caminhoAbsolutoDefinitio))
                            File.Delete(caminhoAbsolutoImagemTemporaria);
                    }

                    listaCaminhosDefinitivos.Add(Path.Combine("/uploads", produtoId, nomeArquivo).Replace("\\", "/"));
                }
            }
            return listaCaminhosDefinitivos;
        }
    }
}
