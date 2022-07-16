using Microsoft.Extensions.Options;
using Nethereum.Web3;
using SnapshotEngine.Models;
using System.Numerics;

namespace SnapshotEngine.Utils
{
    public class ContractUtils
    {
        private readonly BlockchainConfiguration _blockchainConfiguration;
        public ContractUtils(IOptions<BlockchainConfiguration> options)
        {
            _blockchainConfiguration = options.Value;
        }
        
        public async Task<bool> IsContractAddress(string address)
        {
            try
            {
                var web3 = new Web3(_blockchainConfiguration.RpcUrl);
                var code = await web3.Eth.GetCode.SendRequestAsync(address);
                return code != "0x";
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> IsTokenAddress(string address)
        {
            var web3 = new Web3(_blockchainConfiguration.RpcUrl);
            var abi = @"[{""inputs"": [], ""name"": ""totalSupply"", ""outputs"": [ { ""internalType"": ""uint256"", ""name"": """", ""type"": ""uint256"" } ],""stateMutability"": ""view"",""type"": ""function"" }]";
            var contract = web3.Eth.GetContract(abi, address);
            try
            {
                var totalSupplyFunction = contract.GetFunction("totalSupply");
                var totalSupply = await totalSupplyFunction.CallAsync<BigInteger>();
                return totalSupply != 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
