using LojaVirtual.Bibliotecas.Bug;
using LojaVirtual.Modelos;
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

        public static void ApagarTodasImagensTemporarias()
        {
            var caminhoPastaTemp = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/temp");
            var pastaTemp = new DirectoryInfo(caminhoPastaTemp);

            foreach (var arquivo in pastaTemp.GetFiles())
            {
                arquivo.Delete();
            }
        }

        internal static List<Imagem> MoverImagensProduto(List<string> listaCaminhosImagensTemporarias, int produtoId)
        {
            var caminhoDefinitivoPastaProduto = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", produtoId.ToString());
            var directorioExiste = Directory.Exists(caminhoDefinitivoPastaProduto);

            if (!directorioExiste)
                Directory.CreateDirectory(caminhoDefinitivoPastaProduto);

            var listaCaminhosDefinitivos = new List<Imagem>();
            

            foreach (var pastaUploadsImagemTemporaria in listaCaminhosImagensTemporarias.FindAll(x => x.Any()))
            {
                var nomeArquivo = Path.GetFileName(pastaUploadsImagemTemporaria);
                var pastaUploadsImagemDefinitiva = Path.Combine("/uploads", produtoId.ToString(), nomeArquivo).Replace("\\", "/");

                var caminhoAbsolutoImagemTemporaria = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot/uploads/temp", nomeArquivo);

                var caminhoAbsolutoDefinitio = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads",
                    produtoId.ToString(), nomeArquivo);

                if (pastaUploadsImagemDefinitiva == pastaUploadsImagemTemporaria)
                {
                    listaCaminhosDefinitivos.Add(
                    new Imagem
                    {
                        Caminho = Path.Combine("/uploads", produtoId.ToString(), nomeArquivo).Replace("\\", "/"),
                        ProdutoId = produtoId
                    }
                    );

                    continue;
                }

                if (File.Exists(caminhoAbsolutoDefinitio))
                    File.Delete(caminhoAbsolutoDefinitio);

                if (File.Exists(caminhoAbsolutoImagemTemporaria))
                {
                    File.Copy(caminhoAbsolutoImagemTemporaria, caminhoAbsolutoDefinitio);

                    if (File.Exists(caminhoAbsolutoDefinitio))
                        File.Delete(caminhoAbsolutoImagemTemporaria);
                }

                listaCaminhosDefinitivos.Add(
                    new Imagem
                    {
                        Caminho = Path.Combine("/uploads", produtoId.ToString(), nomeArquivo).Replace("\\", "/"),
                        ProdutoId = produtoId
                    }
                    );
            }
            return listaCaminhosDefinitivos;
        }

        internal static void ExcluirImagensProduto(List<Imagem> imagensList)
        {
            foreach (var imagem in imagensList)
            {
                ExcluirImagemProduto(imagem.Caminho);
            }

            var pastaProduto = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", imagensList[0].ProdutoId.ToString());

            if (Directory.Exists(pastaProduto))
                Directory.Delete(pastaProduto);
        }
    }
}
