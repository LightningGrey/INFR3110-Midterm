#include "Wrapper.h"
#include "CheckpointTimeLogger.h"

CheckpointTimeLogger logger;

PLUGIN_API void ResetLogger()
{
	return logger.ResetLogger();
}

PLUGIN_API void SaveCheckpointTime(float RTBC)
{
	return logger.SaveCheckpointTime(RTBC);
}

PLUGIN_API float GetTotalTime()
{
	return logger.GetTotalTime();
}

PLUGIN_API float GetCheckpointTime(int index)
{
	return logger.GetCheckpointTime(index);
}

PLUGIN_API int GetNumCheckpoints()
{
	return logger.GetNumCheckpoints();
}
