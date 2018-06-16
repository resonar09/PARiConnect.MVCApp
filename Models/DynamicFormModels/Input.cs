using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PARiConnect.MVCApp.Models.DynamicFormModels
{
    public class Input
    {
        public string Id { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }
        public string Placeholder { get; set; }
        public string Class { get; set; }
        public int Column { get; set; }
        public int Min { get; set; } 
        public int Max { get; set; }        
        public string Value { get; set; }
        public string PrePendIcon { get; set; }
        public string Pattern { get; set; }
        public bool Validation { get; set; }
        public string ValidationRequiredMessage { get; set; }
        public string ValidationEmailMessage { get; set; }
        public string ValidationNumberMessage { get; set; }
        public bool BatchValidation { get; set; }
        public bool EmailedValidation { get; set; }
        public bool ClientData { get; set; }
        public int ClientDataOrdinal { get; set; }
        public bool ClientDataValidation { get; set; }

        public int TestDataOrdinal { get; set; }
        public string[] Data { get; set; }

        public IEnumerable<Option> Options { get; set; }

        public IEnumerable<Input> List { get; set; }
        public string ValidationDateMessage { get; set; }
        public string OnChange { get; set; }
    }
    public enum InputType { text, email, date, number, radio, password, select, list, checkbox, paragraph, radioVertical, hidden };
    public enum InputIDType {
        age,
        childAge,
        childDOB,
        childFirstName,
        childGender,
        childLastName,
        childName,
        classTaught,
        clientId,
        companyName,
        dateOfBirth,
        dateOfIllness,
        description,
        diagnosis,
        education,
        educationServices,
        educationYears,
        examiner,  //only here for MEMRY.  all others, examiner/rater use raterName
        ethnicity,
        firstName,
        gender,
        grade,
        heightFeet,
        heightInches,
        highestGrade,
        hoursPerWeek,
        howLongKnown,
        howWellKnown,
        inSchool,
        isEmployed,
        lastName,
        livingSituation,
        liveWithChild,
        liveWithYears,
        liveWithMonths,
        maritalStatus,
        normGroup,
        numChildren,
        occupation,
        otherEthnicity,
        otherSchool,
        otherSchoolYear,
        paragraph,
        position,
        primaryEmail,
        purpose,
        raterFirstName,
        raterGender,
        raterLastName,
        raterName,
        referredBy,
        referralReason,
        relationship,
        relationshipDesc,
        school,
        schoolStatus,
        schoolYear,
        secondaryEmail,
        setting,
        specialEducation,
        symptoms,
        testDate,
        testForm,
        testLocation,
        weight,
    };

}