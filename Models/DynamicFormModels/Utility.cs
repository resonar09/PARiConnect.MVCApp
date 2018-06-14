using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PARiConnect.MVCApp.Models.DynamicFormModels
{
    public static class Utility
    {
        public static List<Option> GetOptions(List<string> txtInput, bool firstSelected = true, bool startAtZero = true)
        {
            List<Option> options = new List<Option>();
            int i = startAtZero ? 0 : 1;
            foreach (string str in txtInput)
            {
                options.Add(new Option(i.ToString(), str, (firstSelected && i == 0)));
                i++;
            }

            return options;
        }

        public static List<Option> GetOptionsCustomValues(List<string> txtInput, List<string> valueInput)
        {
            List<Option> options = new List<Option>();
            int i = 0;
            foreach (string str in txtInput)
            {
                options.Add(new Option(valueInput[i], str, i == 0));
                i++;
            }

            return options;
        }

        public static List<Option> GetParentRelationshipOptions()
        {
            return GetOptions(parentRelationshipOptions);
        }
        public static List<Option> GetParent2RelationshipOptions()
        {
            return GetOptions(parent2RelationshipOptions);
        }
        public static List<Option> GetParent3RelationshipOptions()
        {
            return GetOptions(parent3RelationshipOptions);
        }
        public static List<Option> GetTeacherRelationshipOptions()
        {
            return GetOptions(teacherRelationshipOptions);
        }
        public static List<Option> GetTeacher2RelationshipOptions()
        {
            return GetOptions(teacher2RelationshipOptions);
        }
        public static List<Option> GetGeneralRelationshipOptions()
        {
            return GetOptions(generalRelationshipOptions);
        }
        public static List<Option> GetGeneral2RelationshipOptions()
        {
            return GetOptions(general2RelationshipOptions);
        }
        public static List<Option> GetMaritalStatusOptions()
        {
            return GetOptions(maritalStatus);
        }
        public static List<Option> GetKnownOptions()
        {
            return GetOptions(knownOptions);
        }
        public static List<Option> GetGradeOptions()
        {
            return GetOptions(gradeOptions);
        }
        public static List<Option> GetGrade2Options()
        {
            return GetOptions(grade2Options);
        }
        public static List<Option> GetGrade3Options()
        {
            return GetOptions(grade3Options);
        }
        public static List<Option> GetGrade4Options()
        {
            return GetOptions(grade4Options);
        }
        public static List<Option> GetGrade5Options()
        {
            return GetOptions(grade5Options);
        }
        public static List<Option> GetGrade6Options()
        {
            return GetOptions(grade6Options);
        }
        public static List<Option> GetGrade7Options()
        {
            return GetOptions(grade7Options);
        }
        public static List<Option> GetGenderOptions()
        {
            return GetOptions(genderOptions, false, false);
        }
        public static List<Option> GetGender2Options()
        {
            return GetOptions(gender2Options);
        }
        public static List<Option> GetEthnicityOptions()
        {
            return GetOptions(ethnicityOptions);
        }
        public static List<Option> GetEthnicity2Options()
        {
            return GetOptions(ethnicity2Options);
        }
        public static List<Option> GetEthnicity3Options()
        {
            return GetOptions(ethnicity3Options);
        }
        public static List<Option> GetEthnicity4Options()
        {
            return GetOptions(ethnicity4Options);
        }
        public static List<Option> GetEthnicity5Options()
        {
            return GetOptions(ethnicity5Options);
        }
        public static List<Option> GetSchoolStatusOptions()
        {
            return GetOptions(schoolStatusOptions);
        }
        public static List<Option> GetYesNoOptions()
        {
            return GetOptions(yesNoOptions, false);
        }
        public static List<Option> GetYesNo2Options()
        {
            return GetOptions(yesNo2Options, false);
        }
        public static List<Option> GetEducationOptions()
        {
            return GetOptions(educationOptions);
        }
        public static List<Option> GetEducationYearsOptions()
        {
            return GetOptions(educationYearsOptions);
        }
        public static List<Option> GetSchoolOptions()
        {
            return GetOptions(schoolOptions, false, false);
        }
        public static List<Option> GetSchoolYearOptions()
        {
            return GetOptions(schoolYearOptions, false, false);
        }
        public static List<Option> GetSettingOptions()
        {
            return GetOptions(settingOptions);
        }
        public static List<Option> GetPurposeOptions()
        {
            return GetOptions(purposeOptions);
        }
        public static List<Option> GetSymptomsOptions()
        {
            return GetOptions(symptomsOptions);
        }
        public static List<Option> GetLivingSituationOptions()
        {
            return GetOptions(livingSituationOptions);
        }
        public static List<Option> GetTimePerWeekOptions()
        {
            return GetOptions(timePerWeekOptions);
        }

        // Custom values
        public static List<Option> GetAABGradeOptions()
        {
            return GetOptionsCustomValues(aabGradeOptions, aabGradeOptValues);
        }
        public static List<Option> GetAPSGradeOptions()
        {
            return GetOptionsCustomValues(apsGradeOptions, apsGradeOptValues);
        }
        public static List<Option> GetFAMGradeOptions()
        {
            return GetOptionsCustomValues(famGradeOptions, famGradeOptValues);
        }
        public static List<Option> GetFRSBEGradeOptions()
        {
            return GetOptionsCustomValues(frsbeGradeOptions, frsbeGradeOptValues);
        }
        public static List<Option> GetRAITGradeOptions()
        {
            return GetOptionsCustomValues(raitGradeOptions, raitGradeOptValues);
        }
        public static List<Option> GetRCDSGradeOptions()
        {
            return GetOptionsCustomValues(rcdsGradeOptions, rcdsGradeOptValues);
        }
        public static List<Option> GetSEARSAGradeOptions()
        {
            return GetOptionsCustomValues(searsAGradeOptions, searsAGradeOptValues);
        }
        public static List<Option> GetSEARSCGradeOptions()
        {
            return GetOptionsCustomValues(searsCGradeOptions, searsCGradeOptValues);
        }
        public static List<Option> GetSEARSPTGradeOptions()
        {
            return GetOptionsCustomValues(searsPTGradeOptions, searsPTGradeOptValues);
        }
        public static List<Option> GetSIQGradeOptions()
        {
            return GetOptionsCustomValues(siqGradeOptions, siqGradeOptValues);
        }
        public static List<Option> GetSIQJrGradeOptions()
        {
            return GetOptionsCustomValues(siqJrGradeOptions, siqJrGradeOptValues);
        }
        public static List<Option> GetSTAXIGradeOptions()
        {
            return GetOptionsCustomValues(staxiGradeOptions, staxiGradeOptValues);
        }
        public static List<Option> GetTOGRAGradeOptions()
        {
            return GetOptionsCustomValues(tograGradeOptions, tograGradeOptValues);
        }


        public static List<Option> GetCustomEthnicityOptions()
        {
            return GetOptionsCustomValues(customEthnicityOptions, customEthnicityOptValues);
        }

        private static List<string> genderOptions = new List<string>() { "Female", "Male" };
        private static List<string> gender2Options = new List<string>() { "Not Specified", "Female", "Male" };
        private static List<string> parentRelationshipOptions = new List<string>() { "Not Specified", "Parent", "Guardian", "Other" };
        private static List<string> parent2RelationshipOptions = new List<string>() { "Not Specified", "Mother", "Father", "Other" };
        private static List<string> parent3RelationshipOptions = new List<string>() { "Not Specified", "Mother", "Father", "Caregiver", "Other" };
        private static List<string> teacherRelationshipOptions = new List<string>() { "Not Specified", "Teacher", "Counselor", "Other" };
        private static List<string> teacher2RelationshipOptions = new List<string>() { "Not Specified", "Teacher", "Other" };
        private static List<string> generalRelationshipOptions = new List<string>() { "Not Specified", "Child", "Friend", "Parent", "Partner", "Sibling", "Spouse", "Other" };
        private static List<string> general2RelationshipOptions = new List<string>() { "Not Specified", "Biological parent", "Adoptive parent", "Foster parent", "Other legal guardian", "Residential childcare worker", "Other" };
        private static List<string> maritalStatus = new List<string>() { "Not Specified", "Single", "Married", "Divorced", "Widowed", "Other" };
        private static List<string> ethnicityOptions = new List<string>() { "Not Specified", "African American", "Asian", "Caucasian", "Hispanic", "Native American" };
        private static List<string> ethnicity2Options = new List<string>() { "African American", "White", "Latino", "American Indian", "Asian American", "Other" };
        private static List<string> ethnicity3Options = new List<string>() { "Not Specified", "African American", "Asian", "Caucasian", "Hispanic", "Other" };
        private static List<string> ethnicity4Options = new List<string>() { "African American", "Caucasian", "Native American/Alaskan Native", "Asian/Pacific Islander", "Hispanic", "Other" };
        private static List<string> ethnicity5Options = new List<string>() { "African American", "Asian", "Caucasian", "Hispanic", "Native American", "Other" };
        private static List<string> knownOptions = new List<string>() { "Not Specified", "Not Well", "Moderately Well", "Very Well" };
        private static List<string> schoolStatusOptions = new List<string>() { "Not Specified", "In school", "Suspended", "Expelled", "Dropped out", "Out due to illness", "Graduated" };
        private static List<string> yesNoOptions = new List<string>() { "Yes", "No" };
        private static List<string> yesNo2Options = new List<string>() { "", "No", "Yes" };
        private static List<string> educationOptions = new List<string>() { "Not Specified", "Less than High School", "High School", "College", "Master's Degree", "Doctorate", "Other" };
        private static List<string> educationYearsOptions = new List<string>() { "Not Specified", "Less than or equal to 8", "9", "10", "11", "12", "13", "14", "15", "16", "More than 16" };
        private static List<string> gradeOptions = new List<string>() { "Not Specified", "Pre-K", "Kindergarten", "1st", "2nd", "3rd", "4th", "5th", "6th", "7th", "8th", "9th", "10th", "11th", "12th", "College" };
        private static List<string> grade2Options = new List<string>() { "Not Specified", "1st", "2nd", "3rd", "4th", "5th", "6th", "7th", "8th", "9th", "10th", "11th", "12th", "College" };
        private static List<string> grade3Options = new List<string>() { "Not Specified", "1st", "2nd", "3rd", "4th", "5th", "6th", "7th", "8th", "9th", "10th", "11th", "12th" };
        private static List<string> grade4Options = new List<string>() { "Not Specified","Grade 1","Grade 2","Grade 3","Grade 4","Grade 5","Grade 6"
                                                                ,"Grade 7","Grade 8","Grade 9","Grade 10","Grade 11","Grade 12","Grade 13"
                                                                ,"Grade 14","Grade 15","Grade 16","Greater than 16" };
        private static List<string> grade5Options = new List<string>() { "Not Specified", "Preschool","Pre-Kindergarten","Kindergarten","1st Grade","2nd Grade"
                                                                                            ,"3rd Grade","4th Grade","5th Grade","6th Grade","7th Grade","8th Grade"
                                                                                            ,"9th Grade","10th Grade","11th Grade","12th Grade","> 12th Grade"};
        private static List<string> grade6Options = new List<string>() { "Not Specified", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "16+" };
        private static List<string> grade7Options = new List<string>() { "Not Specified", "Pre-K", "K", "1st", "2nd", "3rd", "4th", "5th", "6th", "7th", "8th", "9th", "10th", "11th", "12th" };
        private static List<string> schoolOptions = new List<string>() { "Vocational school / Technical college", "Community college", "Four-year college or university", "Graduate school", "Other" };
        private static List<string> schoolYearOptions = new List<string>() { "Freshman", "Sophomore", "Junior", "Senior", "Graduate", "Other" };
        private static List<string> settingOptions = new List<string>() { "Not Specified", "Outpatient Center", "Psychiatric Unit", "Forensic Treatment Unit", "Assessment Center", "County Jail", "State Prison", "Federal Prison", "Private Office", "Other" };
        private static List<string> purposeOptions = new List<string>() { "Not Specified", "Workman’s Compensation", "Disability", "Neuropsychological", "Forensic", "Psychiatric", "Screening", "Treatment", "External Evaluation", "Pre-Release", "Other" };
        private static List<string> symptomsOptions = new List<string>() { "Psychiatric", "Cognitive", "Low Intelligence" };
        private static List<string> livingSituationOptions = new List<string>() { "Not Specified", "Home", "Residential Center" };
        private static List<string> timePerWeekOptions = new List<string>() { "Not Specified", "0-1 hr", "2-5 hrs", "6-10 hrs", "11-20 hrs", "21-40 hrs", "41-60 hrs", "Over 60 hrs" };

        // Custom values
        private static List<string> aabGradeOptValues = new List<string>() { "0", "PK", "K", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18" };
        private static List<string> aabGradeOptions = new List<string>() { "Not Specified","Pre-K","Kindergarten","1st Grade","2nd Grade","3rd Grade","4th Grade"
                                                                        ,"5th Grade","6th Grade","7th Grade","8th Grade","9th Grade","10th Grade","11th Grade"
                                                                        ,"12th Grade","13 Years","14 Years","15 Years","16 Years","17 Years","18+ Years" };
        private static List<string> apsGradeOptValues = new List<string>() { "0", "6", "7", "8", "9", "10", "11", "12", "13", "14" };
        private static List<string> apsGradeOptions = new List<string>() { "Not Specified", "6th Grade or less", "7th Grade", "8th Grade", "9th Grade", "10th Grade", "11th Grade", "12th Grade", "College", "Not in School" };
        private static List<string> famGradeOptValues = new List<string>() { "0", "PK", "K", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16"};
        private static List<string> famGradeOptions = new List<string>() { "Not Specified","Pre-K","Kindergarten","1st Grade","2nd Grade","3rd Grade","4th Grade"
                                                                        ,"5th Grade","6th Grade","7th Grade","8th Grade","9th Grade","10th Grade","11th Grade"
                                                                        ,"12th Grade","College Freshman","College Sophomore","College Junior","College Senior" };
        private static List<string> frsbeGradeOptValues = new List<string>() { "0", "12 or less", ">12" };
        private static List<string> frsbeGradeOptions = new List<string>() { "Not Specified", "12 years or less", "More than 12 years" };
        private static List<string> raitGradeOptValues = new List<string>() { "0", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "16", "17" };
        private static List<string> raitGradeOptions = new List<string>() { "Not Specified","4th grade or less","5th grade","6th grade","7th grade"
                                                                                                ,"8th grade","9th grade","10th grade","11th grade","12th grade"
                                                                                                ,"Some College","Associate's degree","Bachelor's degree","Post Graduate" };
        private static List<string> rcdsGradeOptValues = new List<string>() { "0", "2", "3", "4", "5", "6" };
        private static List<string> rcdsGradeOptions = new List<string>() { "Not Specified", "2nd Grade", "3rd Grade", "4th Grade", "5th Grade", "6th Grade" };
        private static List<string> searsAGradeOptValues = new List<string>() { "0", "7", "8", "9", "10", "11", "12" };
        private static List<string> searsAGradeOptions = new List<string>() { "", "7th", "8th", "9th", "10th", "11th", "12th" };
        private static List<string> searsCGradeOptValues = new List<string>() { "0", "3", "4", "5", "6" };
        private static List<string> searsCGradeOptions = new List<string>() { "", "3rd", "4th", "5th", "6th" };
        private static List<string> searsPTGradeOptValues = new List<string>() { "-1", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
        private static List<string> searsPTGradeOptions = new List<string>() { "", "K", "1st", "2nd", "3rd", "4th", "5th", "6th", "7th", "8th", "9th", "10th", "11th", "12th" };
        private static List<string> siqGradeOptValues = new List<string>() { "0", "10", "11", "12" };
        private static List<string> siqGradeOptions = new List<string>() { "", "10th Grade", "11th Grade", "12th Grade" };
        private static List<string> siqJrGradeOptValues = new List<string>() { "0", "7", "8", "9" };
        private static List<string> siqJrGradeOptions = new List<string>() { "", "7th Grade", "8th Grade", "9th Grade" };
        private static List<string> staxiGradeOptValues = new List<string>() { "0", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21" };
        private static List<string> staxiGradeOptions = new List<string>() { "Not Specified","6 years or less","7 years","8 years","9 years","10 years",
                                            "11 years","12 years","13 years","14 years","15 years","16 years","17 years",
                                            "18 years","19 years","20 years","More than 20 years" };
        private static List<string> tograGradeOptValues = new List<string>() { "0", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "16", "17" };
        private static List<string> tograGradeOptions = new List<string>() { "Not Specified","4th grade or less","5th grade","6th grade","7th grade"
                                                                                                ,"8th grade","9th grade","10th grade","11th grade","12th grade"
                                                                                                ,"Some College","Associate's degree","Bachelor's degree","Post Graduate" };


        private static List<string> customEthnicityOptValues = new List<string>() { "", "A", "P", "C", "H", "N", "O" };
        private static List<string> customEthnicityOptions = new List<string>() { "Not Specified", "African American", "Asian/Pacific Islander", "Caucasian", "Hispanic", "Native American/Alaskan", "Other" };
    }
}
