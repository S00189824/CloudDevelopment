using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;

namespace CloudDev_Lab
{
    class Program
    {
        

        static async Task Main(string[] args)
        {
            
            await ReadBucketOperation();
            await PutOperation();
            await DeleteOperation();
        }

        static async Task ReadBucketOperation()
        {
            var s3Service = new AmazonS3Client("AKIA4GOIUP2ZOZFJXCVN", "ZpRlzBtp8046b6Hq30nWEZvWtylsgW/rgvF34dqa", RegionEndpoint.EUWest1);

            var buckets = await s3Service.ListBucketsAsync();
            Console.WriteLine(string.Join(",", buckets.Buckets.Select(x => x.BucketName)));

            foreach (var bucket in buckets.Buckets)
            {
                var objects = await s3Service.ListObjectsAsync(bucket.BucketName);
                if (objects != null)
                {
                    Console.WriteLine($"For bucket {bucket.BucketName}, files:{string.Join(",", objects.S3Objects.Select(x => x.Key))}");
                }
            }

            Console.WriteLine(string.Join(",", buckets.Buckets.Select(x => x.BucketName)));
        }

        static async Task PutOperation()
        {
            var s3Service = new AmazonS3Client("AKIA4GOIUP2ZOZFJXCVN", "ZpRlzBtp8046b6Hq30nWEZvWtylsgW/rgvF34dqa", RegionEndpoint.EUWest1);

            var response = await s3Service.PutBucketAsync(new PutBucketRequest
            {
                BucketName = "cfgdhgkujydyjfhjgjuhyfj"
            });

            Console.WriteLine(response.HttpStatusCode);
        }

        static async Task DeleteOperation()
        {
            var s3Service = new AmazonS3Client("AKIA4GOIUP2ZOZFJXCVN", "ZpRlzBtp8046b6Hq30nWEZvWtylsgW/rgvF34dqa", RegionEndpoint.EUWest1);

            var response = await s3Service.DeleteBucketAsync(new DeleteBucketRequest
            {
                BucketName = "cfgdhgkujydyjfhjgjuhyfj"
            });

            Console.WriteLine(response.HttpStatusCode);
        }
    }
}
