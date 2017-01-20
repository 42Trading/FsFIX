﻿module WriteReadUnitTests

open Xunit
open Swensen.Unquote

open Fix44.Fields
open Fix44.CompoundItems
open Fix44.CompoundItemReaders
open Fix44.CompoundItemWriters
open Fix44.Messages
open Fix44.MsgReaders
open Fix44.MsgWriters



[<Fact>]
let MessageWithHeaderTrailerUnit () =
    let bufSize = 4096
    let beginString = BeginString "NMNXPPML"
    let senderCompID = SenderCompID "UPGLIM"
    let targetCompID = TargetCompID "WKOPJXBC"
    let msgSeqNum = MsgSeqNum 0u
    let stn = UTCDateTime.MakeUTCTimestamp.Make(2016, 12, 29, 19, 09, 00)
    let sendingTime = SendingTime stn
    let ttm = UTCDateTime.MakeUTCTimestamp.Make(2016, 12, 29, 19, 09, 00)
    let msg =  {    AllocID = AllocID "XRFGK"
                    Parties = {NoPartyIDsGrp = None}
                    SecondaryAllocID = None
                    TradeDate = None
                    TransactTime = TransactTime ttm
                    AllocStatus = RejectedByIntermediary
                    AllocRejCode = None
                    AllocType = None
                    AllocIntermedReqType = None
                    MatchStatus = None
                    Product = None
                    SecurityType = None
                    Text = None
                    EncodedText = None
                    AllocationInstructionAckNoAllocsGrp = None} |> Fix44.MessageDU.AllocationInstructionAck


    let buf = Array.zeroCreate<byte> bufSize
    let tmpBuf = Array.zeroCreate<byte> bufSize
    let posW = MsgReadWrite.WriteMessageDU 
                                tmpBuf 
                                buf 
                                0 
                                beginString 
                                senderCompID
                                targetCompID
                                msgSeqNum
                                sendingTime
                                msg
    let msgOut = MsgReadWrite.ReadMessage buf posW
    msg =! msgOut




let NoHopsGrp () = 
    let bs = Array.zeroCreate<byte> 1024
    let xIn:NoHopsGrp = {
                HopCompID = HopCompID "RWTM"
                HopSendingTime = None
                HopRefID = Some (HopRefID 0u)
                }
    let posW = WriteNoHopsGrp  bs 0 xIn
    let fieldPosArr = Array.zeroCreate<FIXBufIndexer.FieldPos> 1
    let indexEnd = FIXBufIndexer.Index fieldPosArr bs posW
    let index = FIXBufIndexer.FixBufIndex (indexEnd, fieldPosArr)
    let xOut = ReadNoHopsGrpIdx bs index
    xIn =! xOut



[<Fact>]
let InstrumentLegFG () =
    let bs = Array.zeroCreate<byte> 1024
    let legContractSettlMonth = MonthYear.MakeMonthYear.Make(2016, 12) |> LegContractSettlMonth
    let xIn:InstrumentLegFG = {
                LegSymbol = LegSymbol "DHVC"
                LegSymbolSfx = None
                LegSecurityID = None
                LegSecurityIDSource = None
                NoLegSecurityAltIDGrp = None
                LegProduct = None
                LegCFICode = None
                LegSecurityType = None
                LegSecuritySubType = None
                LegMaturityMonthYear = None
                LegMaturityDate = None
                LegCouponPaymentDate = None
                LegIssueDate = None
                LegRepoCollateralSecurityType = None
                LegRepurchaseTerm = None
                LegRepurchaseRate = None
                LegFactor = None
                LegCreditRating = None
                LegInstrRegistry = None
                LegCountryOfIssue = None
                LegStateOrProvinceOfIssue = None
                LegLocaleOfIssue = None
                LegRedemptionDate = None
                LegStrikePrice = None
                LegStrikeCurrency = None
                LegOptAttribute = None
                LegContractMultiplier = None
                LegCouponRate = None
                LegSecurityExchange = None
                LegIssuer = None
                EncodedLegIssuer = None
                LegSecurityDesc = None
                EncodedLegSecurityDesc = None
                LegRatioQty = None
                LegSide = Some (LegSide 'a')
                LegCurrency = None
                LegPool = None
                LegDatedDate = None
                LegContractSettlMonth = None
                LegInterestAccrualDate = None}
    let posW = WriteInstrumentLegFG  bs 0 xIn
    let fieldPosArr = Array.zeroCreate<FIXBufIndexer.FieldPos> 2
    let indexEnd = FIXBufIndexer.Index fieldPosArr bs posW
    let index = FIXBufIndexer.FixBufIndex (indexEnd, fieldPosArr)
    let xOut = ReadInstrumentLegFGIdx bs index
    xIn =! xOut





[<Fact>]
let InstrumentLegFG2 () =
    let bs = Array.zeroCreate<byte> 1024
    let legContractSettlMonth = MonthYear.MakeMonthYear.Make(2016, 12) |> LegContractSettlMonth
    let xIn:InstrumentLegFG = {
                LegSymbol = LegSymbol "LOPK"
                LegSymbolSfx = None
                LegSecurityID = None
                LegSecurityIDSource = None
                NoLegSecurityAltIDGrp = None
                LegProduct = None
                LegCFICode = None
                LegSecurityType = None
                LegSecuritySubType = None
                LegMaturityMonthYear = None
                LegMaturityDate = None
                LegCouponPaymentDate = None
                LegIssueDate = None
                LegRepoCollateralSecurityType = None
                LegRepurchaseTerm = None
                LegRepurchaseRate = None
                LegFactor = None
                LegCreditRating = None
                LegInstrRegistry = None
                LegCountryOfIssue = None
                LegStateOrProvinceOfIssue = None
                LegLocaleOfIssue = None
                LegRedemptionDate = None
                LegStrikePrice = None
                LegStrikeCurrency = None
                LegOptAttribute = None
                LegContractMultiplier = None
                LegCouponRate = None
                LegSecurityExchange = None
                LegIssuer = None
                EncodedLegIssuer = None
                LegSecurityDesc = None
                EncodedLegSecurityDesc = None
                LegRatioQty = None
                LegSide = None
                LegCurrency = None
                LegPool = None
                LegDatedDate = None
                LegContractSettlMonth = Some (legContractSettlMonth)
                LegInterestAccrualDate = None}
    let posW = WriteInstrumentLegFG  bs 0 xIn
    let fieldPosArr = Array.zeroCreate<FIXBufIndexer.FieldPos> 2
    let indexEnd = FIXBufIndexer.Index fieldPosArr bs posW
    let index = FIXBufIndexer.FixBufIndex (indexEnd, fieldPosArr)
    let xOut = ReadInstrumentLegFGIdx bs index
    xIn =! xOut
    





[<Fact>]
let MassQuoteNoQuoteEntriesGrp () =
    let bs = Array.zeroCreate<byte> 1024
    let xIn:MassQuoteNoQuoteEntriesGrp =
                 {  QuoteEntryID = QuoteEntryID "GKCO"
                    Instrument = None
                    NoLegsGrp = None
                    BidPx = None
                    OfferPx = None
                    BidSize = None
                    OfferSize = None
                    ValidUntilTime = None
                    BidSpotRate = None
                    OfferSpotRate = None
                    BidForwardPoints = None
                    OfferForwardPoints = None
                    MidPx = None
                    BidYield = None
                    MidYield = None
                    OfferYield = None
                    TransactTime = None
                    TradingSessionID = None
                    TradingSessionSubID = None
                    SettlDate = None
                    OrdType = None
                    SettlDate2 = None
                    OrderQty2 = None
                    BidForwardPoints2 = None
                    OfferForwardPoints2 = None
                    Currency = None    } 

    let posW = WriteMassQuoteNoQuoteEntriesGrp  bs 0 xIn
    let fieldPosArr = Array.zeroCreate<FIXBufIndexer.FieldPos> 2 //todo: allowing probe for the next optional field to look past endPos/end of the index, is there a better way to do this
    let indexEnd = FIXBufIndexer.Index fieldPosArr bs posW
    let index = FIXBufIndexer.FixBufIndex (indexEnd, fieldPosArr)
    let xOut = ReadMassQuoteNoQuoteEntriesGrpIdx bs index
    xIn =! xOut



 


[<Fact>]
let MarketDataIncrementalRefreshNoMDEntriesGrp () =
    let bs = Array.zeroCreate<byte> 1024    
    let tm = UTCDateTime.MakeUTCTimeOnly.Make (13, 59, 25, 377)
    let xIn:MarketDataIncrementalRefreshNoMDEntriesGrp = 
          {MDUpdateAction = MDUpdateAction.New;
           DeleteReason = None;
           MDEntryType = None;
           MDEntryID = None;
           MDEntryRefID = None;
           Instrument = None;
           NoUnderlyingsGrp = None;
           NoLegsGrp = None;
           FinancialStatus = None;
           CorporateAction = None;
           MDEntryPx = None;
           Currency = None;
           MDEntrySize = None;
           MDEntryDate = None;
           MDEntryTime = Some (MDEntryTime tm);
           TickDirection = None;
           MDMkt = None;
           TradingSessionID = None;
           TradingSessionSubID = None;
           QuoteCondition = None;
           TradeCondition = None;
           MDEntryOriginator = None;
           LocationID = None;
           DeskID = None;
           OpenCloseSettlFlag = None;
           TimeInForce = None;
           ExpireDate = None;
           ExpireTime = None;
           MinQty = None;
           ExecInst = None;
           SellerDays = None;
           OrderID = None;
           QuoteEntryID = None;
           MDEntryBuyer = None;
           MDEntrySeller = None;
           NumberOfOrders = None;
           MDEntryPositionNo = None;
           Scope = None;
           PriceDelta = None;
           NetChgPrevDay = None;
           Text = None;
           EncodedText = None;}
    let posW = WriteMarketDataIncrementalRefreshNoMDEntriesGrp  bs 0 xIn
    let fieldPosArr = Array.zeroCreate<FIXBufIndexer.FieldPos> 4
    let indexEnd = FIXBufIndexer.Index fieldPosArr bs posW
    let index = FIXBufIndexer.FixBufIndex (indexEnd, fieldPosArr)
    let xOut = ReadMarketDataIncrementalRefreshNoMDEntriesGrpIdx bs index
    xIn =! xOut


[<Fact>]
let NoSidesGrp () =
    let bs = Array.zeroCreate<byte> 1024    

    let ptyId1Grp1:NoPartyIDsGrp = 
                {   PartyID = PartyID "HLFCBGEH"
                    PartyIDSource = None
                    PartyRole = None
                    NoPartySubIDsGrp = Some []} 
    let ptyId1Grp2:NoPartyIDsGrp = 
                         {  PartyID = PartyID "MGDCHFI"
                            PartyIDSource = None
                            PartyRole = None
                            NoPartySubIDsGrp = None}
    
    let noPartyIDsGrp =  [ ptyId1Grp1; ptyId1Grp2 ] |> Option.Some 

    let xIn:NoSidesGrp = 
                {Side = AsDefined
                 ClOrdID = ClOrdID "ICGHV"
                 SecondaryClOrdID = None
                 ClOrdLinkID = None
                 NoPartyIDsGrp = noPartyIDsGrp
                 TradeOriginationDate = None
                 TradeDate = None
                 Account = None
                 AcctIDSource = None
                 AccountType = None
                 DayBookingInst = None
                 BookingUnit = None
                 PreallocMethod = None
                 AllocID = None
                 NoAllocsGrp = None
                 QtyType = None
                 OrderQtyData = {OrderQty = None
                                 CashOrderQty = None
                                 OrderPercent = None
                                 RoundingDirection = None
                                 RoundingModulus = None}
                 CommissionData = {Commission = None
                                   CommType = None
                                   CommCurrency = None
                                   FundRenewWaiv = None}
                 OrderCapacity = None
                 OrderRestrictions = None
                 CustOrderCapacity = None
                 ForexReq = None
                 SettlCurrency = None
                 BookingType = None
                 Text = None
                 EncodedText = None
                 PositionEffect = None
                 CoveredOrUncovered = None
                 CashMargin = None
                 ClearingFeeIndicator = None
                 SolicitedFlag = None
                 SideComplianceID = None}
    let posW = WriteNoSidesGrp  bs 0 xIn
    let fieldPosArr = Array.zeroCreate<FIXBufIndexer.FieldPos> 128
    let indexEnd = FIXBufIndexer.Index fieldPosArr bs posW
    let index = FIXBufIndexer.FixBufIndex (indexEnd, fieldPosArr)
    let xOut = ReadNoSidesGrpIdx bs index
    xIn =! xOut



[<Fact>]
let NoPartyIDsGrp () =
    let bs = Array.zeroCreate<byte> 1024
    let ptyId1Grp1:NoPartyIDsGrp = 
                {   PartyID = PartyID "HLFCBGEH"
                    PartyIDSource = None
                    PartyRole = None
                    NoPartySubIDsGrp = Some []} 
    let ptyId1Grp2:NoPartyIDsGrp = 
                         {  PartyID = PartyID "MGDCHFI"
                            PartyIDSource = None
                            PartyRole = None
                            NoPartySubIDsGrp = None}
    let ptyIdGrp = ptyId1Grp1
    let posW = WriteNoPartyIDsGrp  bs 0 ptyIdGrp
    let fieldPosArr = Array.zeroCreate<FIXBufIndexer.FieldPos> 128
    let indexEnd = FIXBufIndexer.Index fieldPosArr bs posW
    let index = FIXBufIndexer.FixBufIndex (indexEnd, fieldPosArr)
    let xOut = ReadNoPartyIDsGrpIdx bs index
    ptyIdGrp =! xOut



[<Fact>]
let EncodedHeadline1 () =
    let bs = Array.zeroCreate<byte> 1024
    let eh = EncodedHeadline [||] |> Fix44.FieldDU.EncodedHeadline
    let posW = Fix44.FieldDU.WriteField bs 0 eh
    let ehOut = Fix44.FieldDU.ReadField bs 0
    eh =! ehOut
    


[<Fact>]
let EncodedHeadline2 () =
    let bs = Array.zeroCreate<byte> 1024
    let eh = EncodedHeadline [||] 
    let posW = Fix44.FieldWriters.WriteEncodedHeadline bs 0 eh
    let pos2, tag = FIXBuf.readTag bs 0
    let len = bs.Length - pos2
    let ehOut = Fix44.FieldReaders.ReadEncodedHeadlineIdx bs pos2 len
    eh =! ehOut




[<Fact>]
let EncodedHeadline3 () =
    let bs = Array.zeroCreate<byte> 1024
    let eh = EncodedHeadline [||] |> Fix44.FieldDU.EncodedHeadline
    let posW = Fix44.FieldDU.WriteField bs 0 eh
    let ehOut = Fix44.FieldDU.ReadField bs 0
    eh =! ehOut