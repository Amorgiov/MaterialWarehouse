using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Models;
using Npgsql;

namespace MaterialWarehouse.Models.Repository
{
    public class MaterialRepository
    {
        protected string _connectionString;
        
        public MaterialRepository(string conn)
        {
            _connectionString = conn;
        }

        public void CreateInputMaterial(InputMaterials movingMaterials)
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                var NpgsqlQuery =
                    "INSERT INTO input_material (date , documentid, supplier, price, materialid) VALUES (@TransDate, @DocumentId, @SupplierName, @Price, @MaterialId);";
                db.Execute(NpgsqlQuery, movingMaterials);
            }
        }

        public void CreateTransferMaterial(MovingMaterials movingMaterials)
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                var NpgsqlQuery =
                    "INSERT INTO transfer_material (date, documentid, price, materialid) VALUES (@TransDate, @DocumentId, @Price, @MaterialId)";
                db.Execute(NpgsqlQuery, movingMaterials);
            }
        }

        public List<Materials> GetMaterials()
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                return db.Query<Materials>("SELECT * FROM materials").ToList();
            }
        }
        
        public List<MovingMaterials> GetInputMaterials()
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                return db.Query<MovingMaterials>("SELECT * FROM input_material").ToList();
            }
        }
        
        public List<MovingMaterials> GetTransferMaterials()
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                return db.Query<MovingMaterials>("SELECT * FROM transfer_material").ToList();
            }
        }
        
        public List<OutputMaterials> GetOutputMaterials()
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                return db.Query<OutputMaterials>("SELECT * FROM output_material").ToList();
            }
        }
        
        public void CreateOutputMaterial(MovingMaterials movingMaterials)
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                var NpgsqlQuery =
                    "INSERT INTO output_material (date, documentid, price, materialid) VALUES (@TransDate, @DocumentId, @Price, @MaterialId)";
                db.Execute(NpgsqlQuery, movingMaterials);
            }
        }
        
        public void CreateNewMateral(Materials materials)
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                var NpgsqlQuery = "INSERT INTO materials (Name, Type, Price) VALUES (@name, @type, @price)";
                db.Execute(NpgsqlQuery, materials);
            }
        }
        
        public Materials Get(int id)
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                return db.Query<Materials>("SELECT * FROM materials WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }
        
        public void UpdateMaterial(Materials materials)
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                var sqlQuery = "UPDATE materials SET name = @Name, type = @Type, price = @Price WHERE id = @Id AND (@Name, @Type, @Price) IS NOT NULL";
                db.Execute(sqlQuery, materials);
            }
        }
    }
}