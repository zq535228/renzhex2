/* 
* Copyright 2004-2009 James House 
* 
* Licensed under the Apache License, Version 2.0 (the "License"); you may not 
* use this file except in compliance with the License. You may obtain a copy 
* of the License at 
* 
*   http://www.apache.org/licenses/LICENSE-2.0 
*   
* Unless required by applicable law or agreed to in writing, software 
* distributed under the License is distributed on an "AS IS" BASIS, WITHOUT 
* WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the 
* License for the specific language governing permissions and limitations 
* under the License.
* 
*/

using X_Quartz.Simpl;

namespace X_Quartz.Spi
{
	/// <summary>
	/// An IInstanceIdGenerator is responsible for generating the clusterwide unique 
	/// instance id for a <see cref="IScheduler" /> nodde.
	/// <p>
	/// This interface may be of use to those wishing to have specific control over 
	/// the mechanism by which the <see cref="IScheduler" /> instances in their 
	/// application are named.
	/// </p>
	/// 
	/// </summary>
	/// <seealso cref="SimpleInstanceIdGenerator" />
	public interface IInstanceIdGenerator
	{
		/// <summary> Generate the instance id for a <see cref="IScheduler" />
		/// 
		/// </summary>
		/// <returns> The clusterwide unique instance id.
		/// </returns>
		string GenerateInstanceId();
	}
}