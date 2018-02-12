using System;
using Xunit;

namespace FizFuz.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Execute_Expect1_when1()
        {
            var fizfuz = new FizFuz();
            string result = fizfuz.Execute(1);
            Assert.Equal("1", result);
        }
        [Fact]
        public void Execute_Expect12_when2()
        {
            var fizfuz = new FizFuz();
            string result = fizfuz.Execute(2);
            Assert.Equal("1,2", result);
        }
        [Fact]
        public void Execute_Expect12fiz_when3()
        {
            var fizfuz = new FizFuz();
            string result = fizfuz.Execute(3);
            Assert.Equal("1,2,fiz", result);
        }
        [Fact]
        public void Execute_Expect12fiz_when4()
        {
            var fizfuz = new FizFuz();
            string result = fizfuz.Execute(4);
            Assert.Equal("1,2,fiz,4", result);
        }
        [Fact]
        public void Execute_Expect12fizfuz_when5()
        {
            var fizfuz = new FizFuz();
            string result = fizfuz.Execute(5);
            Assert.Equal("1,2,fiz,4,fuz", result);
        }
        [Fact]
        public void Execute_Expect12fizfuzfiz_when6()
        {
            var fizfuz = new FizFuz();
            string result = fizfuz.Execute(6);
            Assert.Equal("1,2,fiz,4,fuz,fiz", result);
        }
        [Fact]
        public void Execute_Expect12fizfuzfiz_when10()
        {
            var fizfuz = new FizFuz();
            string result = fizfuz.Execute(10);
            Assert.Equal("1,2,fiz,4,fuz,fiz,7,8,fiz,fuz", result);
        }
        [Fact]
        public void Execute_Expect12fizfuzfiz_when15()
        {
            var fizfuz = new FizFuz();
            string result = fizfuz.Execute(15);
            Assert.Equal("1,2,fiz,4,fuz,fiz,7,8,fiz,fuz,11,fiz,13,14,fizfuz", result);
        }
        [Fact]
        public void Execute_Expect12fizfuzfiz_when30()
        {
            var fizfuz = new FizFuz();
            string result = fizfuz.Execute(30);
            Assert.Equal("1,2,fiz,4,fuz,fiz,7,8,fiz,fuz,11,fiz,13,14,fizfuz,16,17,fiz,19,fuz,fiz,22,23,fiz,fuz,26,fiz,28,29,fizfuz", result);
        }


    }
}
