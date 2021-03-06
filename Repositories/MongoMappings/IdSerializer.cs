using Domain;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Repositories.MongoMappings
{
	internal sealed class IdSerializer : SerializerBase<Id>
	{
		public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, Id id)
		{
			UpdateIdIfNone(id);
			context.Writer.WriteObjectId(new ObjectId(id.StringId));
		}

		private void UpdateIdIfNone(Id id)
		{
			if (id == Id.None)
			{
				var objectId = ObjectId.GenerateNewId();
				var bsonObjectId = new BsonObjectId(objectId);
				id.SetIfNone(bsonObjectId.ToString());
			}
		}

		public override Id Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
		{
			var objectId = context.Reader.ReadObjectId();
			return Id.IdFrom(objectId.ToString());
		}
	}
}