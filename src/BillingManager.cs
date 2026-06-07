using System;

namespace HospitalBillingSystem.src
{
    public class BillingManager
    {
        public string PatientId { get; private set; }
        public string ServiceId { get; private set; }
        public double Cost { get; private set; }
        public bool IsApprovedByInsurance { get; private set; }

        public BillingManager(string patientId, string serviceId, double cost)
        {
            PatientId = patientId;
            ServiceId = serviceId;
            Cost = cost;
            IsApprovedByInsurance = false;
        }

       
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
            
            if (!isIdentityValid || !isRiskComplete)
            {
                throw new InvalidOperationException("DENIED: Patient identity unverified or risk file incomplete.");
            }

        
            if (hasInsurance)
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
                else
                {
                    IsApprovedByInsurance = true;
                    return "APPROVED: Covered by insurance. Share updated.";
                }
            }
            else
            {
               
                if (patientBalance >= Cost)
                {
                    return "APPROVED: Deducted fully from patient direct balance.";
                }
                else
                {
                    return "DENIED: No insurance coverage and insufficient direct balance.";
                }
            }
        }
    }
}
