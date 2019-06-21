using System;
using _02_ClaimRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_ClaimTest
{
    [TestClass]
    public class ClaimTest
    {
        private ClaimRepository _claimRepo;
        private Claim _claim;
        private Claim _lateClaim;

        [TestInitialize]
        public void Arrange()
        {
            _claimRepo = new ClaimRepository();
            _claim = new Claim(1, ClaimType.Car, "Car Accident on 464", 400, Convert.ToDateTime("4/25/2018"), Convert.ToDateTime("4/27/2018"),true);
            _lateClaim = new Claim(1, ClaimType.Car, "Car Accident on 464", 400, Convert.ToDateTime("1/25/2018"), Convert.ToDateTime("5/27/2018"), false);
        }

        [TestMethod]
        public void ClaimPOCOTests()
        {
            Claim claim = new Claim();

            DateTime expected = new DateTime(2018, 04, 25);
            DateTime expectedDateOfClaim = new DateTime(2018, 04, 27);

            Assert.AreEqual(1, _claim.ClaimID);
            Assert.AreEqual(ClaimType.Car, _claim.TypeOfClaim);
            Assert.AreEqual("Car Accident on 464", _claim.Description);
            Assert.AreEqual(400, _claim.ClaimAmount);
            Assert.AreEqual(expected, _claim.DateOfIncident);
            Assert.AreEqual(expectedDateOfClaim, _claim.DateOfClaim);
            Assert.AreEqual(true, _claim.IsValid);
        }

        [TestMethod]

        public void AddClaimToQueue()
        {
            DateTime newDate = new DateTime(2018, 4, 25);
            //Arrange
            ClaimRepository claimRepo = new ClaimRepository();
            Claim claim = new Claim(1, ClaimType.Car, "Car Accident on 464", 400, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27), true);

            //Act 
            _claimRepo.AddClaimToQueue(claim);

            int expected = 1;
            int actual = _claimRepo.GetListOfClaims().Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsClaimValid()
        {
            _claimRepo.AddClaimToQueue(_claim);
            bool actual = _claim.IsValid;
            bool expected = true;

            _claimRepo.AddClaimToQueue(_lateClaim);
            bool lateActual = _lateClaim.IsValid;
            bool lateExpected = false;

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(lateActual, lateExpected);
        }

        [TestMethod]
        public void ViewNextClaim()
        {
            _claimRepo.AddClaimToQueue(_claim);
            Claim actual = _claimRepo.ViewNextClaim();
            Claim expected = _claim;
            Assert.AreEqual(actual, expected);

        }

        [TestMethod]
        public void TakeNextClaim()
        {
            _claimRepo.AddClaimToQueue(_claim);
            _claimRepo.TakeNextClaim();

            int actual = _claimRepo.GetListOfClaims().Count;
            int expected = 0;

            Assert.AreEqual(actual, expected);

        }
    }
}
