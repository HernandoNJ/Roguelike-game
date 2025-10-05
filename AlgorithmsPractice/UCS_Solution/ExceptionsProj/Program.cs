//// Catch use cases
//// 1. Null exception
//Person ReadPersonData(int personId)
//{
//    // Code from other dev, maybe API or DB
//    // Read() may throw an exception, for example, null
//    return _externalDataReader.Read(personId);
//}

//Person ReadPersonData(int personId)
//{
//    try
//    {
//        return _externalDataReader.Read(personId);
//    }
//    catch (NoDataException ex
//    {
//        // The dev decides that null is allowed to let the app continue
//        return null;
//    }
//}

//// 2. Possible TimeoutException in remote server
//SaveToRemoteDatabase(person);

//// Code to retry after some seconds
//while (retriesCount > 5)
//{
//    try
//    {
//        SaveToRemoteDatabase(person);
//        break;
//    }
//    catch (TimeoutException ex)
//    {
//        // wait 5s
//        retriesCount--;
//    }
//}

//// 3. Global try catch block 

