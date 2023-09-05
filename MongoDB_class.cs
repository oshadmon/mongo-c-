/**
 * The following provides a simplified example for connecting and communicating with MongoDB 
 * MongoDB Download - https://www.mongodb.com/try/download/community
 * MongoDB Connection - https://www.mongodb.com/docs/drivers/csharp/current/quick-start/#std-label-csharp-quickstart
 */

using System;
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
         * Connect to MongoDB based on CONN_INFO and database
         * 
         * :args:
         *      conn_info:str - MongoDB connection information
         *      db_name:str - database to store content in
         * :params: 
         *      cur:IMongoDatabase - cursor for communicating with MongoDB 
         * :return: 
         *      cur
         */

        // connect MongDB connection 
        var client = new MongoClient(conn_info);

        // create cursor 
        var cur = client.GetDatabase(db_name);
    }

    private static BsonDocument IsCollection(string, conn_info, string collection_name){
        collectionss  database.ListCollectionNames().ToList();

    }
    public static BsonDocument CheckCollection(IMongoDatabase cur, string colllection_name, str column_name, string column_value){
        /**
         * if a row exists based on a given value 
         * 
         * :args: 
         *      cur:IMongoDatabase - cursor for communicating with MongoDB
         *      collection_name:str - collection ("table") to look into
         *      column_name:str - which column to check by 
         *      column_value:str - value to search against 
         * :params: 
         *      collection - returned row 
         * :return: 
         *      if cursor is able to find row, return it, otherwise return None
         */

        //  get collection to uuse 
        var collection = GetCollection<BsonDocument>(colllection_name);
        iifif f 




    }

}

using System;
using MongoDB.Driver;

public class MongoDB
{
    public static IMongoDatabase ConnectMongoDB(string conn_info, string db_name)
    {
        /**
         * Connect to MongoDB based on CONN_INFO and database
         * 
         * :args:
         *      conn_info: str - MongoDB connection information
         *      db_name: str - database to store content in
         * :return: 
         *      cur: IMongoDatabase - cursor for communicating with MongoDB 
         */

        // Connect to MongoDB using the provided connection information
        var client = new MongoClient(conn_info);

        // Get a reference to the specified database
        var db = client.GetDatabase(db_name);

        return db;
    }
at
    public static IMongoCollection<BsonDocument> GetCollection(IMongoDatabase db, string collectionName)
    {
        /**
         * Get a reference to a MongoDB collection within the specified database
         * 
         * :args: 
         *      db: IMongoDatabase - MongoDB database
         *      collectionName: str - name of the collection
         * :return: 
         *      collection: IMongoCollection<BsonDocument> - MongoDB collection
         */

        // Get a reference to the specified collection
        var collection = db.GetCollection<BsonDocument>(collectionName);

        return collection;
    }

    public static BsonDocument CheckContent(IMongoCollection<BsonDocument> collection, string name)
    {
        /**
         * Check if a row exists based on a given value in a MongoDB collection
         * 
         * :args: 
         *      collection: IMongoCollection<BsonDocument> - MongoDB collection
         *      name: str - value within a column to search by
         * :return: 
         *      content: BsonDocument - returned row if found, otherwise null
         */

        // Define a filter to search for a document with the specified value in a column
        var filter = Builders<BsonDocument>.Filter.Eq("ColumnName", name); // Replace "ColumnName" with your actual column name

        // Try to find a document that matches the filter
        var content = collection.Find(filter).FirstOrDefault();

        return content;
    }
}
