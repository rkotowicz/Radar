using Radar.Model;
using System;
using Xunit;

namespace Radar.Tests
{
    public class CourseAngleTests : IDisposable
    {
        CourseAngle _sut1Zero = new CourseAngle(0);
        CourseAngle _sut1Right = new CourseAngle(90);
        public CourseAngleTests()
		{

		}
        [Fact]
        public void AfterInit_ShouldBeEqualToInit()
        {
            Assert.Equal(0.0, _sut1Zero.Heading);
            Assert.Equal(90.0, _sut1Right.Heading);
        }

        [Fact]
        public void AfterInit_ShouldBeWithinRange()
        {
            var _sut = new CourseAngle(360);
            Assert.Equal(0.0, _sut);
            _sut = new CourseAngle(360 + 90);
            Assert.Equal(90.0, _sut);
        }

        [Fact]
        public void AddingSubs_ShouldBeChanging()
        {
            var _sut = _sut1Zero + 90;
            Assert.Equal(90.0, _sut);
            _sut = _sut - 90;
            Assert.Equal(0.0, _sut);
            _sut = _sut - 30 + 90 -50;
            Assert.Equal(10.0, _sut);
        }
        public void Dispose()
        {
            //base.Dispose();
        }
    }
}