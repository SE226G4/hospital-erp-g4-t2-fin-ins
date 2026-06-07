using System;

namespace HospitalBillingSystem.src
{
    public class RefactoredBillingManager
    {
        public string PatientId { get; private set; }
        public string ServiceId { get; private set; }
        public double Cost { get; private set; }
        public bool IsApprovedByInsurance { get; private set; }

        public RefactoredBillingManager(string patientId, string serviceId, double cost)
        {
            PatientId = patientId;
            ServiceId = serviceId;
            Cost = cost;
            IsApprovedByInsurance = false;
        }

        // التابع الأساسي بعد إعادة الهيكلة - التعقيد الحلقي يساوي 2 فقط
        public string VerifyCoverageAndApproveService(
            bool isIdentityValid, 
            bool isRiskComplete, 
            bool hasInsurance, 
            bool isPolicyExpired, 
            double coveragePercent, 
            bool requiresPreApproval, 
            bool isApprovedByCompany, 
            double patientBalance)
        {
            ValidatePatientIdentityAndFile(isIdentityValid, isRiskComplete);

            if (hasInsurance)
            {
                return ProcessInsuranceFlow(isPolicyExpired, coveragePercent, requiresPreApproval, isApprovedByCompany, patientBalance);
            }

            return ProcessDirectPaymentFlow(patientBalance);
        }

        // تابع مساعد رقم 1
        private void ValidatePatientIdentityAndFile(bool isIdentityValid, bool isRiskComplete)
        {
            if (!isIdentityValid || !isRiskComplete)
            {
                throw new InvalidOperationException("DENIED: Patient identity unverified or risk file incomplete.");
            }
        }

        // تابع مساعد رقم 2
        private string ProcessInsuranceFlow(bool isPolicyExpired, double coveragePercent, bool requiresPreApproval, bool isApprovedByCompany, double patientBalance)
        {
            if (isPolicyExpired)
            {
                return "DENIED: Insurance policy is expired.";
            }

            double coverageAmount = Cost * coveragePercent;
            double patientShare = Cost - coverageAmount;

            if (requiresPreApproval && !isApprovedByCompany)
            {
                return "PENDING: Service requires pre-approval from insurance company.";
            }

            if (patientShare > 0 && patientBalance < patientShare)
            {
                return "DENIED: Insufficient patient balance for the remaining share.";
            }

            IsApprovedByInsurance = true;
            return "APPROVED: Covered by insurance. Share updated.";
        }

       
        private string ProcessDirectPaymentFlow(double patientBalance)
        {
            if (patientBalance >= Cost)
            {
                return "APPROVED: Deducted fully from patient direct balance.";
            }
            
            return "DENIED: No insurance coverage and insufficient direct balance.";
        }
    }
}