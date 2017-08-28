using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication10.Dtos;
using WebApplication10.Models;

namespace WebApplication10.Controllers
{
    public class MembersController : ApiController
    {
        private MemberContext db;
        public MembersController()
        {
            db = new MemberContext();
        }
        public IEnumerable<MemberDto> GetMembers()
        {
            return db.Members.ToList().Select(Mapper.Map<Member,MemberDto>);
        }
        public MemberDto GetMember(int id)
        {
            var member = db.Members.SingleOrDefault(c => c.MemId == id);
            if (member == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Mapper.Map<Member,MemberDto>(member);

        }
        [HttpPost]
      //  public MemberDto CreateMember(MemberDto memberDto)
        public IHttpActionResult CreateMember(MemberDto memberDto)
        {
            if (!ModelState.IsValid)
                // throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();
            var member = Mapper.Map<MemberDto, Member>(memberDto);
            db.Members.Add(member);
            db.SaveChanges();
            memberDto.MemId = member.MemId;
            return Created(new Uri(Request.RequestUri +"/" + member.MemId),memberDto);
      //      return memberDto();
        }
        [HttpPut]
        public void UpdateMember(int id,MemberDto memberDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var memberInDb = db.Members.SingleOrDefault(c => c.MemId == id);
            if (memberInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(memberDto, memberInDb);
            //memberInDb.MemName = member.MemName;
            //memberInDb.MemEmail = member.MemEmail;
            //memberInDb.MemAddress = member.MemAddress;
            db.SaveChanges();
          

        }
        [HttpDelete]
        public void DeleteMember(int id)
        {
            var memberInDb = db.Members.SingleOrDefault(c => c.MemId == id);
            if (memberInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            db.Members.Remove(memberInDb);
            db.SaveChanges();
        }
        }
}
