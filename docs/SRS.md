  # Software Requirements Specification (SRS)___

## Project: Hospital ERP System
## Module/Subsystem: Finance & Insurance (FIN-INS)
**Version:** 1.0  
**Date:** 2026-05-08

---

## 1. Introduction
### 1.1 Purpose
The purpose of this document is to define the functional and non-functional requirements for the Finance & Insurance (FIN-INS) module. This document serves as a guide for developers, testers, and the integration team to ensure accurate financial operations within the Hospital ERP System.

### 1.2 Scope
The FIN-INS module handles the financial lifecycle of patients.
* **What it will do:** Aggregate service costs (stay, surgery, pharmacy), calculate insurance coverage percentages, verify payments before service delivery, and issue final invoices.
* **What it will NOT do:** It will not handle clinical diagnosis, inventory restocking, or payroll management for hospital staff.

### 1.3 Definitions, Acronyms, and Abbreviations
| Term | Definition |
| :--- | :--- |
| ERP | Enterprise Resource Planning |
| FIN-INS | Finance and Insurance Module |
| SRS | Software Requirements Specification |
| JWT | JSON Web Token (for security) |

### 1.4 References
* IEEE 830-1998 Standard for Software Requirements Specifications.
* Hospital ERP Master Architectural Document.
* GitHub Project Board for FIN-INS Module.

### 1.5 Overview
This document is organized into sections covering the product perspective, detailed user stories following the Agile approach, performance requirements, and system attributes like security and reliability.

---

## 2. Overall Description
### 2.1 Product Perspective
The FIN-INS module is a component of the larger Hospital ERP System. It acts as a central financial hub that consumes data from clinical and logistical modules to process billing.

* **2.1.1 System Interfaces:** RESTful APIs to communicate with Pharmacy and Ward modules.
* **2.1.2 User Interfaces:** Web-based interface following the shared React design system.
* **2.1.3 Hardware Interfaces:** Standard desktop computers and thermal receipt printers.
* **2.1.4 Software Interfaces:** Runs on Windows/Linux, utilizes SQL Server database.
* **2.1.5 Communications Interfaces:** HTTP/HTTPS protocols for all API calls.

### 2.2 Product Functions
* Consolidated billing for all hospital services.
* Automated insurance coverage verification.
* Real-time payment status tracking.
* Final discharge invoice generation.

### 2.3 User Characteristics
* **Accountants:** High technical and financial expertise.
* **Billing Clerks:** Moderate technical expertise, responsible for daily transactions.

### 2.4 Constraints, Assumptions, and Dependencies
* **Dependency:** Accurate cost data must be provided by the Pharmacy and Operations modules.
* **Constraint:** Compliance with local financial laws and patient data privacy.

---

## 3. Specific Requirements (Agile Approach) :

### 3.0.1 Functional Requirements (FRs)

1. The system shall generate unified invoices.
2. The system shall calculate insurance coverage automatically.
3. The system shall validate payment before service approval.
4. The system shall receive billing data from all operational modules.
5. The system shall generate final patient invoices.

---

### 3.0.2 Non-Functional Requirements (NFRs)

1. The system shall ensure secure financial transactions.
2. The system shall support high availability.
3. The system shall process invoices in less than 2 seconds.
4. The system shall maintain data consistency between modules.
5. The system shall support scalable integration.

### 3.1 External Interface Requirements
* **API Endpoint:** `POST /api/fin-ins/invoice/calculate`
* **Format:** JSON response including total cost, insurance deduction, and net amount.

### 3.2 System Features & User Stories

#### 3.2.1 Feature: Billing Aggregation
* **Description:** Gathering costs from all hospital departments.
* **Priority:** High.
* **User Stories:**
    * **Story 1:** As a system, I want to aggregate costs from all departments (Stay, Operations, Pharmacy) into a single patient invoice.
        * *Acceptance Criteria:* Invoice includes timestamped items from all modules.
        * *GitHub Issue:* #1

#### 3.2.2 Feature: Insurance Processing
* **Description:** Managing insurance coverage and remaining balances.
* **Priority:** High.
* **User Stories:**
    * **Story 1:** As a billing officer, I want to calculate insurance coverage automatically to show the remaining balance.
        * *Acceptance Criteria:* Correct percentage is deducted based on the patient's insurance plan.
        * *GitHub Issue:* #2
    * **Story 2:** As a system, I want to verify payment or insurance coverage before allowing any service to be provided.
        * *Acceptance Criteria:* System blocks service entry if no financial coverage is verified.
        * *GitHub Issue:* #3

---

## 3.3 Performance Requirements
* The system shall process invoice calculations in less than 2 seconds.
* The system shall support up to 50 concurrent billing requests.

## 3.4 Logical Database Requirements
* **Entities:** `PatientAccount`, `InvoiceItem`, `InsuranceProvider`, `PaymentTransaction`.

## 3.5 Software System Attributes
* **Security:** Multi-factor authentication for accountants and 256-bit encryption for financial data.
* **Reliability:** 99.5% system availability during hospital working hours.

---

## 4. Appendices
### Appendix A: Glossary & Models
* Entity-Relationship Diagrams :
* 1-Activity Diagram :(drawio)
  
 ![link](https://github.com/Dahhamm/software-engineering2/blob/main/photo_2026-05-18_07-14-11.png)
* [Link of Activity Diagram:](https://github.com/Dahhamm/software-engineering2/blob/main/Activity%20_diagram_SE2.drawio)
  
* 2-Components Diagram :(drawio)
  
 ![link](https://github.com/Dahhamm/software-engineering2/blob/main/component_diagram_billing_system.png)
* [Link of Component Diagram:](https://github.com/Dahhamm/software-engineering2/blob/main/component_diagram_billing_system.drawio)
  
* 3-Link of [Use Case Diagram](https://github.com/mohammedsywt/SE2/blob/main/Hospital%20Managment%20System4%20FIN-INS.vpp) (visual paradigm)
* 4-ERD [ مخطط قاعدة البيانات والERDالحركي  ]( https://github.com/mohammaadkh/FIN_INS/blob/1597e32dec660d874337c65237336e99ff1fb57c/ERD_Model2_FIN_INS.png)
* 5-class_diagrame[finall_class_diaggram](https://github.com/mohammaadkh/FIN_INS/blob/1597e32dec660d874337c65237336e99ff1fb57c/class_diagram.png)
* code_class_diagrame[the code that drow class diagram on drow oi](https://github.com/mohammaadkh/FIN_INS/blob/1597e32dec660d874337c65237336e99ff1fb57c/%D8%A7%D9%84%D9%83%D9%84%D8%A7%D8%B3%20%D8%A7%D9%84%D8%B0%D9%8A%20%D8%B9%D9%85%D9%84%D9%86%D8%A7%20%D9%84%D9%87%20%D8%A7%D8%B3%D8%AA%D9%8A%D8%B1%D8%A7%D8%AF%20%D8%B9%D9%84%D9%89%20drow%20oi%20%20%D9%81%D8%B8%D9%87%D8%B1%20%D9%85%D8%AE%D8%B7%D8%B7%20class%20diagram.txt)
* 6-sequence diagram:(drawio)
   ![link](https://github.com/alwkayanalassaadmohamad2-boop/mohamadsoftware123/blob/main/sequance123456789.jpg)
* link of [sequence diagram](https://github.com/alwkayanalassaadmohamad2-boop/mohamadsoftware123)
* 7-Link of [logic Flow](https://github.com/SE226G4/hospital-erp-g4-t2-fin-ins/blob/main/docs/Logic_Flow.md) (Mermaid)
### Appendix B: GitHub Traceability Checklist
* [x] Every User Story in Section 3.2 has a corresponding GitHub Issue.
* [x] Every GitHub Issue has an appropriate label.
