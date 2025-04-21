using System;
using System.ComponentModel.DataAnnotations;

namespace OncoAIApp.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите имя пациента.")]
        [Display(Name = "Имя пациента")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите возраст пациента.")]
        [Display(Name = "Возраст пациента")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Пожалуйста, выберите пол пациента.")]
        [Display(Name = "Пол пациента")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Пожалуйста, опишите симптомы.")]
        [Display(Name = "Описание симптомов")]
        public string Symptoms { get; set; }

        [Display(Name = "Путь к изображению")]
        public string ImagePath { get; set; }

        [Display(Name = "Дата добавления")]
        public DateTime DateAdded { get; set; } = DateTime.Now;
    }
}