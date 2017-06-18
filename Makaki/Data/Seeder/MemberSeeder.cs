using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Makaki.Model;


namespace Makaki.Data.Seeder
{
    public class MemberSeeder : ISeeder
    {
        private readonly Random _random = new Random();
        public void Seed(DatabaseContext context)
        {            
            List<Address> addresses = context.Addresses.ToList();
            List<EmploymentStatus> employmentStatuses = context.EmploymentStatuses.ToList();
            List<MembershipType> membershipTypes = context.MembershipTypes.ToList();
            List<MemberCategory> memberCategories = context.MemberCategories.ToList();
            List<Branch> branches = context.Branches.ToList();
            List<Guardian> guardians = context.Guardians.ToList();

            List<Section> sections= context.Sections.ToList();
            List<AffiliationFeeType> affiliationFees = context.AffiliationFeeTypes.ToList();
            List<MemberFunction> memberFunctions = context.MemberFunctions.ToList();
            List<Coach> coaches = context.Coaches.ToList();
            

            List<Member> members = new List<Member>();            

            using (StreamReader streamReader = new StreamReader(GetStream(), Encoding.UTF8))
            {
                while (!streamReader.EndOfStream)
                {
                    string readLine = streamReader.ReadLine();

                    if (readLine != null && !readLine.TrimStart().StartsWith("#"))
                    {
                        string[] strings = readLine.Split(new[] { ';' }, StringSplitOptions.None);
                        int cnt = 0;

                        Member member = new Member();                        
                        member.MemberCode = GetString(strings[cnt++]);
                        member.FirstName = GetString(strings[cnt++]);
                        member.LastName = GetString(strings[cnt++]);
                        member.Address = GetList(addresses, Convert.ToInt32(strings[cnt++]));
                        member.PID = GetString(strings[cnt++]);
                        member.Birthday = GetDate(strings[cnt++]);
                        member.EmploymentStatus = GetList(employmentStatuses, Convert.ToInt32(strings[cnt++]));
                        member.EmploymentPlace= GetString(strings[cnt++], "-");
                        member.EmploymentDetails = GetString(strings[cnt++], "-");
                        member.MembershipType= GetList(membershipTypes, Convert.ToInt32(strings[cnt++]));
                        member.MemberCategory = GetList(memberCategories, Convert.ToInt32(strings[cnt++]));
                        member.Branch = GetList(branches, Convert.ToInt32(strings[cnt++]));
                        member.Phone = GetString(strings[cnt++], "-");
                        member.MobilePhone= GetString(strings[cnt++], "-");
                        member.BussinessPhone = GetString(strings[cnt++], "-");
                        member.Email= GetString(strings[cnt++]);
                        member.Guardian = GetList(guardians, Convert.ToInt32(strings[cnt++]));
                        member.Gender = GetString(strings[cnt++], "-");
                        member.RequiredPhysical= GetBoolean(strings[cnt++], "-");
                        member.LastPhysical = GetDate(strings[cnt++], "-");
                        member.CardNumber = GetString(strings[cnt++], "-");
                        member.AssociationRegistrationNumber = GetString(strings[cnt++], "-");
                        member.Section = GetList(sections, Convert.ToInt32(strings[cnt++]));
                        member.AffiliationFeeType = GetList(affiliationFees, Convert.ToInt32(strings[cnt++]));
                        member.MemberFunction = GetList(memberFunctions, Convert.ToInt32(strings[cnt++]));
                        member.JoinDate = GetDate(strings[cnt++], "-");
                        member.Coach = GetList(coaches, 93); //todo

                        members.Add(member);

                       if (members.Count > 20)                        
                            break;
                    }
                }
            }

            context.Members.AddRange(members);
        }
       

        private Stream GetStream()
        {
            List<string> resourcNames = Assembly.GetExecutingAssembly().GetManifestResourceNames().ToList();
            string result = resourcNames.Find(x => x.EndsWith("Members.csv"));
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(result);

            if (stream == null)
                throw new Exception("Unable to load members.csv. It should be in embeded assests folder.");

            return stream;
        }

        private T GetList<T>(List<T> list, int index) where T : class
        {
            if (index < 0)
                return null;

            var newIndex = index < list.Count ? index : _random.Next(0, list.Count);

            return list[newIndex];
        }

        private bool GetBoolean(string s, string nullValue = null)
        {
            if (s == nullValue)
                return false;

            return s == "1";
        }

        private string GetString(string s, string nullValue = null)
        {
            return s == nullValue ? string.Empty : s;
        }

        private DateTime? GetDate(string s, string nullValue = null)
        {
            if (string.IsNullOrWhiteSpace(s) || s == nullValue)
                return null;


            DateTime dateTime = DateTime.ParseExact(s, "yyyy/MM/dd", CultureInfo.InvariantCulture);

            return dateTime;
        }        
    }
}
