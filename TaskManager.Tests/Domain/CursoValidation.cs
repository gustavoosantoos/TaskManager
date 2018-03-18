using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Domain.Models.Entities;
using TaskManager.Utils.Validators;
using Xunit;

namespace TaskManager.Tests.Domain
{
    public class CursoValidation
    {
        [Fact]
        public void CursoComNomeComMaisDe4CaracteresEhValido()
        {
            Curso curso = new Curso();
            curso.Nome = "Teste";

            Assert.True(ObjectValidator.IsValid(curso));
        }

        [Fact]
        public void CursoComNomeNuloEhInvalido()
        {
            Curso curso = new Curso();

            Assert.False(ObjectValidator.IsValid(curso));
        }

        [Fact]
        public void CursoComNomeComMenosDe5CaracteresEhInvalido()
        {
            Curso curso = new Curso();
            curso.Nome = "Test";

            Assert.False(ObjectValidator.IsValid(curso));
        }

        [Fact]
        public void CursoComNomeComMaisDe60CaracteresEhInvalido()
        {
            Curso curso = new Curso();
            curso.Nome = "Mussum Ipsum, cacilds vidis litro abertis. Tá deprimidis, eu conheço uma cachacis que pode alegrar sua vidis. Posuere libero varius. Nullam a nisl ut ante blandit hendrerit. Aenean sit amet nisi. Aenean aliquam molestie leo, vitae iaculis nisl. Nec orci ornare consequat. Praesent lacinia ultrices consectetur. Sed non ipsum felis.";

            Assert.False(ObjectValidator.IsValid(curso));
        }
    }
}
