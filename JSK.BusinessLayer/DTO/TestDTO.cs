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
    }
}
