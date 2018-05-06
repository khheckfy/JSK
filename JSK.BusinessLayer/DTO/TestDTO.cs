﻿using System.Collections.Generic;

namespace JSK.BusinessLayer.DTO
{
    public class TestDTO
    {
        /// <summary>
        /// Id теста
        /// </summary>
        public int TestId { set; get; }
        /// <summary>
        /// Название теста
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        /// Вопросы теста выдаются в случайном порядке
        /// </summary>
        public bool IsRandomQuestionsOrder { set; get; }

        /// <summary>
        /// Активный тест
        /// </summary>
        public bool IsActive { set; get; }

        public List<TestQuestionDTO> Questions { set; get; }
    }
}
