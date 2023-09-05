/**
 * The following provides a simplified example for connecting and communicating with MongoDB 
 * MongoDB Download - https://www.mongodb.com/try/download/community
 * MongoDB Connection - https://www.mongodb.com/docs/drivers/csharp/current/quick-start/#std-label-csharp-quickstart
 */

using System;
using System.Collections.Generic; // Add this using statement for List<>
using MongoDB.Driver; // MongoDB driver 

/**
 * connection information to MongoDB. 
 * 
 * Connection with Username / password: mongodb://{USERNAME}:{PASSWORD}@{MONGODB_IP}:{MONGODB_PORT} 
 */
static string CONN_INFO = "mongodb://localhost:27017" 

public class MongoDB{
    public static IMongoDatabase  ConnectMongDB(string conn_info, string db_name){
        /**
         * Connect to MongoDB based on CONN_INFO and database name
         * :args:
         *      conn_info:str - MongoDB connection information
         *      db_name:str - database to store content in
         * :params: 
         *      conn:MongoClient - MongoDB client 
         *      cur:IMongoDatabase - cursor for communicating with MongoDB 
         * :return: 
         *      cursor for MongoDB
         */
        IMongoDatabase cur = null;

        
        try { 
            // connect MongDB connection 
            var client = new MongoClient(conn_info);

            // create cursor for MongoDB connection
            cur = client.GetDatabase(db_name);
        } catch (Exception ex){
            Console.WriteLine(f"Failed create a connection  to MongoDB (Error: {ex})");
        }

            return cur; 
    }

    private static bool IsCollection(IMongoDatabase, cur, string collection_name){
        /**
         * Check whether a collection exists
         * 
         * :args: 
         *      cur:IMongoDatabase - cursor for communicating with MongoDB
         *      collection_name:str - collection ("table") to look into
         *  :params: 
         *      is_collection:bool - whether the collection exists or not 
         *      collections - collections in MongoDB 
         *  :return: 
         *      if collection_name in collections return True else return False
         */
        
        var bool is_collection = false;
        List<string> collections = null;

        try {
            collections = database.ListCollectionNames().ToList(); // list of all collections 
        }
        catch (Exception ex) {
            Console.WriteLine(f"Failed to get a list of collections (Error: {ex})");
        } finally {
            if (collections != null && collectionNames.Contains(collection_name)) { // check whether collection exists 
                is_collection = true;
            }
        }

        return is_collection
    }
    
    public static BsonDocument CheckCollection(IMongoDatabase cur, string colllection_name, str column_name, string column_value){
        /**
         * get document (row) based on criteria -- if found need to open document 
         * :args: 
         *      cur:IMongoDatabase - cursor for communicating with MongoDB
         *      collection_name:str - collection ("table") to look into
         *      column_name:str - which column to check by 
         *      column_value:str - value to search against 
         * :params: 
         *      is_collection:bool - whether or not collection exists 
         *      filter:Builders - criteria to search by 
         * :return: 
         *     if fails to locate collection returns null 
         *     if fails to locate "row" based on criteria returns null
         *     if able to locate "row" based on criteria returns row 
         */
        bool is_collection = IsCollection(cur = cur, collection_name = colllection_name); 
        
        if (! is_collection){ // if collection doesn't exist returns null (need to create collection / file) 
            return null; 
        }
        
        // create a filter criteria based on column_name (ex. file_name) and correspondig value 
        var filter = Builders<BsonDocument>.Filter.Eq(column_name, column_value);

        // Create a filter criteria based on column_name (ex. file_name) and corresponding value 
        var filter = Builders<BsonDocument>.Filter.Eq(column_name, column_value);

        // Get the document (row) based on the filter; if not found, return null
        var collection = cur.GetCollection<BsonDocument>(collection_name);
        return collection.Find(filter).FirstOrDefault();

    }

    public static IMongoCollection<BsonDocument> CreateCollection(IMongoDatabase cur, IMongoDatabase cur, string colllection_name){
        /**
         * Create collection for data to be stored in
         * 
         * :args:
         *      cur:IMongoDatabase - cursor for communicating with MongoDB
         *      collection_name:str - collection ("table") to look into
         * :params: 
         *      status:bool - wether collection was created
         * :return: 
         *      status
         */

        var collection = null;

        try{
            collection = cur.CreateCollection(collection_name)
        } catch(Exception ex) {
            Console.WriteLine(f"Failed create a new collection - {collection_name) (Error: {ex})");
        }

        return collection;

    }


    public static bool InsertData(IMongoCollection collection, string file_name, byte file_content){
        /**
         * Write content into MongoDB 
         * :sample row:
         *      create_ts:datetime - create timestamp 
         *      update_ts:datetime - update timestamp 
         *      creator:str - person who created the file (based on windows username) 
         *      updator:str - last person to update file (based on windows username)
         *      file_name:str - file name 
         *      file_content:bytes - actual file blob
         * :args: 
         *      cur:IMongoDatabase - cursor for communicating with MongoDB
         *      collection:str - collection ("table") to look into
         *      file_name:str - file name 
         *      file_conent:bytes - file content
         * :params: 
         *      status:bool 
         *      creator:str - User who created the new "row" 
         *      timestamp:DateTime - current timestamp 
         * :return: 
         *      status
         */
        bool status = true;
        string creator = Environment.UserName; // windows user 
        DateTime timestamp = DateTime.Now; // current timestamp 

        var document = new BsonDocument { // create "row" for container 
            { "create_ts", timestamp },
            { "update_ts", timestamp },
            { "name", file_content }
            { "creator", creator },
            { "updator", creator },
            { "content", file_content }

        };

        try{ // write row to container 
            collection.InsertOne(document);
        }catch(Exception ex){
            Console.WriteLine(f"Failed write content into container (Error: {ex})");
            status = true; 
        } 

        return status; 

    }

    public static bool UpdateData(IMongoCollection collection, string file_name, BsonDocument content){
        /**
         * Update MongoDB row with new content
         * :args: 
         *      cur:IMongoDatabase - cursor for communicating with MongoDB
         * :params: 
         *      status:bool 
         *      updator:str - last person to change the file 
         *      timestamp:DateTime - current timestamp 
         * :return: 
         *      status
         */
        bool status = false;
        string updator = Environment.UserName; // windows user 
        DateTime timestamp = DateTime.Now; // current timestamp (used for update row) 

        return status;
    }
}

/**
 * Main
 *  1. connect to MongoDB 
 *  2. CreateCollection (This will create and/or connect to collection)
 */ 