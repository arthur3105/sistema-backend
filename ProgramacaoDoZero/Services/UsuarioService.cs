﻿using ProgramacaoDoZero.Common;
using ProgramacaoDoZero.Entities;
using ProgramacaoDoZero.Models;
using ProgramacaoDoZero.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgramacaoDoZero.Services
{
    public class UsuarioService
    {
        private string _connectionString;
        
        public UsuarioService(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        
        public LoginResult Login(string email, string senha)
        {
            var result = new LoginResult();

            var usuarioRepository = new UsuarioRepository(_connectionString);

            var usuario = usuarioRepository.ObterUsuarioPorEmail(email);

            if(usuario != null)
            {
                //usuário existe
                if(usuario.Senha == senha)
                {
                    //senha válida
                    result.sucesso = true;
                    result.usuarioGuid = usuario.UsuarioGuid;
                }
                else
                {
                    //senha inválida
                    result.sucesso = false;
                    result.mensagem = "Usuário ou senha inválidos";
                }
            }
            else
            {
                //usuário não existe
                result.sucesso = false;
                result.mensagem = "Usuário ou senha inválidos";
            }

            return result;
        }

        public CadastroResult Cadastro(string nome, string sobrenome, string email, string telefone, string genero, string senha)
        {
            var result = new CadastroResult();

            var usuarioRepository = new UsuarioRepository(_connectionString);

            var usuario = usuarioRepository.ObterUsuarioPorEmail(email);

            if(usuario != null)
            {
                //usuário já existe
                result.sucesso = false;
                result.mensagem = "Usuário já existe no sistema";
            }
            else
            {
                //usuario não existe
                usuario = new Usuario();
                usuario.Nome = nome;
                usuario.Sobrenome = sobrenome;                
                usuario.Email = email;
                usuario.Telefone = telefone;
                usuario.Genero = genero;
                usuario.Senha = senha;
                usuario.UsuarioGuid = Guid.NewGuid();

                var insertResult = usuarioRepository.Inserir(usuario);                               

                if (insertResult > 0)
                {
                    //inseriu com sucesso
                    result.sucesso = true;
                    result.usuarioGuid = usuario.UsuarioGuid;
                }
                else
                {
                    //erro ao inserir
                    result.sucesso = false;
                    result.mensagem = "Erro ao inserir usuário. Tente novamente";
                }
            }

            return result;
        }

        public EsqueceuSenhaResult EsqueceuSenha(string email)
        {
            var result = new EsqueceuSenhaResult();

            var usuarioRepositoy = new UsuarioRepository(_connectionString);

            var usuario = usuarioRepositoy.ObterUsuarioPorEmail(email);

            if(usuario == null)
            {
                //não existe
                result.sucesso = false;
                result.mensagem = "Usuário não existe para esse email";
            }
            else
            {
                //usuário existe
                var emailSender = new EmailSender();

                var assunto = "Recuperação de Senha";
                var corpo = "Sua senha é " + usuario.Senha;

                emailSender.Enviar(assunto, corpo, usuario.Email);
                
            }

            return result;
        }

        public Usuario ObterUsuario(Guid usuarioGuid)
        {
            var usuario = new UsuarioRepository(_connectionString).ObterPorGuid(usuarioGuid);

            return usuario;
        }
    }
}
