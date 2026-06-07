using System;
using Xunit; 
using HospitalBillingSystem.src;

namespace HospitalBillingSystem.tests
{
    public class BillingManagerTests
    {
        // ==========================================
        // أولاً: حالات فحص التابع الأصلي (قبل التحسين - 7 حالات)
        // ==========================================

        [Fact]
        public void Original_Test_1_IdentityOrRisk_Invalid_ThrowsException()
        {
            var manager = new BillingManager("PT-990", "SRV-SURGERY", 1000.0);
            Assert.Throws<InvalidOperationException>(() => 
                manager.VerifyCoverageAndApproveService(false, false, true, false, 0.8, false, true, 500));
        }

        [Fact]
        public void Original_Test_2_Policy_Is_Expired_Denies()
        {
            var manager = new BillingManager("PT-990", "SRV-SURGERY", 1000.0);
            string result = manager.VerifyCoverageAndApproveService(true, true, true, true, 0.8, false, true, 500);
            Assert.Contains("DENIED: Insurance policy is expired", result);
        }

        [Fact]
        public void Original_Test_3_No_PreApproval_Returns_Pending()
        {
            var manager = new BillingManager("PT-990", "SRV-SURGERY", 1000.0);
            string result = manager.VerifyCoverageAndApproveService(true, true, true, false, 0.8, true, false, 500);
            Assert.Contains("PENDING: Service requires pre-approval", result);
        }

        [Fact]
        public void Original_Test_4_PatientShareBalance_Insufficient_Denies()
        {
            var manager = new BillingManager("PT-990", "SRV-SURGERY", 1000.0);
            string result = manager.VerifyCoverageAndApproveService(true, true, true, false, 0.5, false, true, 100);
            Assert.Contains("DENIED: Insufficient patient balance", result);
        }

        [Fact]
        public void Original_Test_5_Insurance_Is_Valid_Approves()
        {
            var manager = new BillingManager("PT-990", "SRV-SURGERY", 1000.0);
            string result = manager.VerifyCoverageAndApproveService(true, true, true, false, 0.8, true, true, 300);
            Assert.Contains("APPROVED: Covered by insurance", result);
            Assert.True(manager.IsApprovedByInsurance);
        }

        [Fact]
        public void Original_Test_6_DirectPayment_Is_Sufficient_Approves()
        {
            var manager = new BillingManager("PT-990", "SRV-SURGERY", 1000.0);
            string result = manager.VerifyCoverageAndApproveService(true, true, false, false, 0, false, false, 1200);
            Assert.Contains("APPROVED: Deducted fully", result);
        }

        [Fact]
        public void Original_Test_7_DirectPayment_Insufficient_Denies()
        {
            var manager = new BillingManager("PT-990", "SRV-SURGERY", 1000.0);
            string result = manager.VerifyCoverageAndApproveService(true, true, false, false, 0, false, false, 400);
            Assert.Contains("DENIED: No insurance coverage", result);
        }


        // ==========================================
        // ثانياً: حالات فحص التابع المحسّن (بعد الـ Refactoring - 7 حالات)
        // ==========================================

        [Fact]
        public void Refactored_Test_1_IdentityOrRisk_Invalid_ThrowsException()
        {
            var manager = new RefactoredBillingManager("PT-990", "SRV-SURGERY", 1000.0);
            Assert.Throws<InvalidOperationException>(() => 
                manager.VerifyCoverageAndApproveService(false, false, true, false, 0.8, false, true, 500));
        }

        [Fact]
        public void Refactored_Test_2_Policy_Is_Expired_Denies()
        {
            var manager = new RefactoredBillingManager("PT-990", "SRV-SURGERY", 1000.0);
            string result = manager.VerifyCoverageAndApproveService(true, true, true, true, 0.8, false, true, 500);
            Assert.Contains("DENIED: Insurance policy is expired", result);
        }

        [Fact]
        public void Refactored_Test_3_No_PreApproval_Returns_Pending()
        {
            var manager = new RefactoredBillingManager("PT-990", "SRV-SURGERY", 1000.0);
            string result = manager.VerifyCoverageAndApproveService(true, true, true, false, 0.8, true, false, 500);
            Assert.Contains("PENDING: Service requires pre-approval", result);
        }

        [Fact]
        public void Refactored_Test_4_PatientShareBalance_Insufficient_Denies()
        {
            var manager = new RefactoredBillingManager("PT-990", "SRV-SURGERY", 1000.0);
            string result = manager.VerifyCoverageAndApproveService(true, true, true, false, 0.5, false, true, 100);
            Assert.Contains("DENIED: Insufficient patient balance", result);
        }

        [Fact]
        public void Refactored_Test_5_Insurance_Is_Valid_Approves()
        {
            var manager = new RefactoredBillingManager("PT-990", "SRV-SURGERY", 1000.0);
            string result = manager.VerifyCoverageAndApproveService(true, true, true, false, 0.8, true, true, 300);
            Assert.Contains("APPROVED: Covered by insurance", result);
            Assert.True(manager.IsApprovedByInsurance);
        }

        [Fact]
        public void Refactored_Test_6_DirectPayment_Is_Sufficient_Approves()
        {
            var manager = new RefactoredBillingManager("PT-990", "SRV-SURGERY", 1000.0);
            string result = manager.VerifyCoverageAndApproveService(true, true, false, false, 0, false, false, 1200);
            Assert.Contains("APPROVED: Deducted fully", result);
        }

        [Fact]
        public void Refactored_Test_7_DirectPayment_Insufficient_Denies()
        {
            var manager = new RefactoredBillingManager("PT-990", "SRV-SURGERY", 400);
            string result = manager.VerifyCoverageAndApproveService(true, true, false, false, 0, false, false, 200);
            Assert.Contains("DENIED: No insurance coverage", result);
        }
    }
}