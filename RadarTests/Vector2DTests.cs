using Radar.Model;
using System;
using Xunit;

namespace Radar.Tests
{
    public class Vector2DTests : IDisposable
    {
        Vector2D _sut1Zero = new Vector2D(0, 0);
        Vector2D _sut1One = new Vector2D(1,1);
        public Vector2DTests()
        {

        }

        [Fact]
        public void Vector_From0AngleIsNorth()
        {
            var _sut = Vector2D.NewWithAngle(1, 0);
            Assert.Equal(0.0, _sut.Heading);
        }


        [Fact]
        public void Heading_ShouldBe0_North()
        {
            var _sut = new Vector2D(0, 0);
            Assert.Equal(0.0, _sut.Heading);
            _sut = new Vector2D(0, 1);
            Assert.Equal(0.0, _sut.Heading);
            _sut = Vector2D.NewWithAngle(1, 0);
            Assert.Equal(0.0, _sut.Heading);
        }

        [Fact]
        public void Heading_ShouldBe90_East()
        {
            var _sut = new Vector2D(1, 0);
            Assert.Equal(90.0, _sut.Heading);
            _sut = new Point3D(1, 0, 0) - new Point3D(0, 0, 0);
            Assert.Equal(90.0, _sut.Heading);
            _sut = Vector2D.NewWithAngle(1, 90);
            Assert.Equal(90.0, _sut.Heading);
        }

        [Fact]
        public void Heading_ShouldBe180_South()
        {
            var _sut = new Vector2D(0, -1);
            Assert.Equal(180.0, _sut.Heading);
            _sut = Vector2D.NewWithAngle(1, 180);
            Assert.Equal(180.0, _sut.Heading);
        }

        [Fact]
        public void Heading_ShouldBe270_West()
        {
            var _sut = new Vector2D(-1, 0);
            Assert.Equal(270.0, _sut.Heading);
            _sut = Vector2D.NewWithAngle(1, 270);
            Assert.Equal(270.0, _sut.Heading);
        }

        [Fact]
        public void Length_ShouldBeSqrt50()
        {
            var _sut = new Vector2D(5, 5);
            Assert.Equal((float)Math.Sqrt(50.0), _sut.Length);
        }

        [Fact]
        public void Heading_ShouldBeFineAfterRotation()
        {
            var _sut = Vector2D.NewWithAngle(10, 30);
            _sut >>= 90;
            Assert.Equal(10, _sut.Length);
            Assert.Equal(30+90, _sut.Heading);
            _sut >>= 90;
            Assert.Equal(30 + 90 + 90, _sut.Heading);
        }

        [Fact]
        public void Vector2d_ShouldBeNormalized()
        {
            var _sut = new Vector2D(5, 5);
            _sut = _sut.Normalize();
            Assert.Equal(1.0, _sut.Length);
            Assert.Equal(45.0, _sut.Heading);
        }


        public void Dispose()
        {
            //base.Dispose();
        }
    }
}