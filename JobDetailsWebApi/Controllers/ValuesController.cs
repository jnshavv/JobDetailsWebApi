

using JobDetailsWebApi.Data;
using JobDetailsWebApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ValuesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/JobDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobDetails>>> GetJobDetails()
        {
            var jobDetails = await _context.JobDetails
                .FromSqlRaw("EXEC GetJobDetails")
                .AsNoTracking()
                .ToListAsync();

            return Ok(jobDetails);
        }

        // GET: api/JobDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobDetails>> GetJobDetail(int id)
        {
            var jobDetail = await _context.JobDetails
                .FromSqlRaw("EXEC GetJobDetailsById @Id", new SqlParameter("@Id", id))
                .AsNoTracking()
                .ToListAsync();
            //.SingleOrDefaultAsync();
            var jobd = jobDetail.FirstOrDefault();



            if (jobd == null)
            {
                return NotFound();
            }

            return Ok(jobDetail);
        }

        // POST: api/JobDetails
        [HttpPost]
        public async Task<ActionResult<JobDetails>> CreateJobDetail(JobDetails jobDetail)
        {
            var parameters = new[]
            {
                new SqlParameter("@Name", jobDetail.Name),
                new SqlParameter("@Email", jobDetail.Email),
                new SqlParameter("@Job_Role", jobDetail.JobRole),
                new SqlParameter("@Total_Experience", jobDetail.TotalExperience),
                new SqlParameter("@Current_Ctc", jobDetail.CurrentCtc),
                new SqlParameter("@Expected_Ctc", jobDetail.ExpectedCtc),
                new SqlParameter("@Reason_For_JobChange", jobDetail.ReasonForJobChange),
                new SqlParameter("@Notice_period", jobDetail.NoticePeriod),
                new SqlParameter("@Current_City", jobDetail.CurrentCity),
                new SqlParameter("@Pincode", jobDetail.Pincode),
                new SqlParameter("@Date", jobDetail.Date),
                new SqlParameter("@Upload_Cv", jobDetail.UploadCv)
            };

            var result = await _context.JobDetails
                .FromSqlRaw("EXEC AddJobDetails @Name, @Email, @Job_Role, @Total_Experience, @Current_Ctc, @Expected_Ctc, @Reason_For_JobChange, @Notice_period, @Current_City, @Pincode, @Date, @Upload_Cv", parameters)
                .AsNoTracking()
                .ToListAsync();

            var createdJobDetail = result.FirstOrDefault();

            if (createdJobDetail == null)
            {
                return BadRequest("Unable to create job detail.");
            }

            return CreatedAtAction(nameof(GetJobDetail), new { id = createdJobDetail.Id }, createdJobDetail);
        }

        // PUT: api/JobDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJobDetail(int id, JobDetails jobDetail)
        {
            var parameters = new[]
            {
                new SqlParameter("@Id", id),
                new SqlParameter("@Name", jobDetail.Name),
                new SqlParameter("@Email", jobDetail.Email),
                new SqlParameter("@Job_Role", jobDetail.JobRole),
                new SqlParameter("@Total_Experience", jobDetail.TotalExperience),
                new SqlParameter("@Current_Ctc", jobDetail.CurrentCtc),
                new SqlParameter("@Expected_Ctc", jobDetail.ExpectedCtc),
                new SqlParameter("@Reason_For_JobChange", jobDetail.ReasonForJobChange),
                new SqlParameter("@Notice_period", jobDetail.NoticePeriod),
                new SqlParameter("@Current_City", jobDetail.CurrentCity),
                new SqlParameter("@Pincode", jobDetail.Pincode),
                new SqlParameter("@Date", jobDetail.Date),
                new SqlParameter("@Upload_Cv", jobDetail.UploadCv)
            };

            var result = await _context.JobDetails
                .FromSqlRaw("EXEC UpdateJobDetails @Id, @Name, @Email, @Job_Role, @Total_Experience, @Current_Ctc, @Expected_Ctc, @Reason_For_JobChange, @Notice_period, @Current_City, @Pincode, @Date, @Upload_Cv", parameters)
                .AsNoTracking()
                .ToListAsync();

            var updatedJobDetail = result.FirstOrDefault();

            if (updatedJobDetail == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/JobDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobDetail(int id)
        {
            var result = await _context.Database
                .ExecuteSqlRawAsync("EXEC DeleteJobdetails @Id", new SqlParameter("@Id", id));

            if (result == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
