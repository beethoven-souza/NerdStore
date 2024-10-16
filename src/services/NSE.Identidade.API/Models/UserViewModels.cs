﻿using System.ComponentModel.DataAnnotations;

namespace NSE.Identidade.API.Models
{
  public class UsoarioRegistro
  {
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [StringLength(100, ErrorMessage = "O campo precisa ter entre {2} e {1} caracteres.", MinimumLength = 6)]
    public string Senha { get; set; }

    [Compare("Senha", ErrorMessage = "As senhas não conferem.")]
    public string SenhaConfirmacao { get; set; }
  }

  public class UsoarioLogin
  {
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [StringLength(100, ErrorMessage = "O campo precisa ter entre {2} e {1} caracteres.", MinimumLength = 6)]
    public string Senha { get; set; }
  }

  public class UsuarioRespostaLogin
  {
    public string AccessToken { get; set; }
    public double ExpiresIn { get; set; }
    public UsuarioToken UsuarioToken { get; set; }
  }

  public class UsuarioToken 
  {
    public string Id { get; set; }
    public string Email {  set; get; }
    public IEnumerable<UsuarioClaim> Claims { get; set; }
  }

  public class UsuarioClaim 
  {
    public string Value { get; set; }
    public string Type { get; set; }
  }


}
