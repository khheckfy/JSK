using JSK.BusinessLayer.DTO;
using JSK.BusinessLayer.Interfaces;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace JSK.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TestCreateTests()
        {
            TestDTO test = new TestDTO()
            {
                IsActive = true,
                IsRandomQuestionsOrder = true,
                Name = "Test of test",
            };

            for (int i = 0; i < 5; i++)
            {
                TestQuestionDTO question = new TestQuestionDTO()
                {
                    Question = $"Question {i}",
                    IsActive = true,
                    IsSingleAnswer = false,
                    TestQuestionAnswers = new System.Collections.Generic.List<TestQuestionAnswerDTO>()
                    {
                        new TestQuestionAnswerDTO(){Answer=$"Answer {i}_1", IsActive=true, IsCorrect=false },
                        new TestQuestionAnswerDTO(){Answer=$"Answer {i}_2", IsActive=true, IsCorrect=false },
                        new TestQuestionAnswerDTO(){Answer=$"Answer {i}_3", IsActive=true, IsCorrect=true },
                        new TestQuestionAnswerDTO(){Answer=$"Answer {i}_4", IsActive=true, IsCorrect=false },
                        new TestQuestionAnswerDTO(){Answer=$"Answer {i}_5", IsActive=true, IsCorrect=true },
                        new TestQuestionAnswerDTO(){Answer=$"Answer {i}_6", IsActive=true, IsCorrect=true },
                        new TestQuestionAnswerDTO(){Answer=$"Answer {i}_7", IsActive=true, IsCorrect=false }
                    }
                };
            }
            Mock<ITestService> mockService = new Mock<ITestService>();
            mockService.Setup(arg => arg.Test_SaveAsync(test)).Returns(Task.FromResult(0));

        }
    }
}
