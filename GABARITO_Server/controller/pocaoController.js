import connection from "../database.js";

let tableName = "Pocao";

async function getPocao(req,res){
  try{
    let result = await connection.query(`SELECT * FROM ${tableName};`);
    res.send(result.recordset);
    console.table(result.recordset);
    }
    catch(ex){
        console.log(ex.message);
    }
}
  
  async function getPocaoById(req,res) {
    try{
      let result = await connection.query(`SELECT * FROM ${tableName} WHERE ID = ${req.params.id};`);
      res.send(result.recordset);
      console.table(result.recordset);
      }
      catch(ex){
          console.log(ex.message);
      }
  }

export {getPocao, getPocaoById}