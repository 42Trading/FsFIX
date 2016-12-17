module Fix44.MessageDU

open Fix44.Messages
open Fix44.MsgWriteFuncs
open Fix44.MsgReadFuncs


type FIXMessage =
    | Advertisement of Advertisement
    | AllocationInstruction of AllocationInstruction
    | AllocationInstructionAck of AllocationInstructionAck
    | AllocationReport of AllocationReport
    | AllocationReportAck of AllocationReportAck
    | AssignmentReport of AssignmentReport
    | BidRequest of BidRequest
    | BidResponse of BidResponse
    | BusinessMessageReject of BusinessMessageReject
    | CollateralAssignment of CollateralAssignment
    | CollateralInquiry of CollateralInquiry
    | CollateralInquiryAck of CollateralInquiryAck
    | CollateralReport of CollateralReport
    | CollateralRequest of CollateralRequest
    | CollateralResponse of CollateralResponse
    | Confirmation of Confirmation
    | ConfirmationAck of ConfirmationAck
    | ConfirmationRequest of ConfirmationRequest
    | CrossOrderCancelReplaceRequest of CrossOrderCancelReplaceRequest
    | CrossOrderCancelRequest of CrossOrderCancelRequest
    | DerivativeSecurityList of DerivativeSecurityList
    | DerivativeSecurityListRequest of DerivativeSecurityListRequest
    | DontKnowTrade of DontKnowTrade
    | Email of Email
    | ExecutionReport of ExecutionReport
    | Heartbeat of Heartbeat
    | IndicationOfInterest of IndicationOfInterest
    | ListCancelRequest of ListCancelRequest
    | ListExecute of ListExecute
    | ListStatus of ListStatus
    | ListStatusRequest of ListStatusRequest
    | ListStrikePrice of ListStrikePrice
    | Logon of Logon
    | Logout of Logout
    | MarketDataIncrementalRefresh of MarketDataIncrementalRefresh
    | MarketDataRequest of MarketDataRequest
    | MarketDataRequestReject of MarketDataRequestReject
    | MarketDataSnapshotFullRefresh of MarketDataSnapshotFullRefresh
    | MassQuote of MassQuote
    | MassQuoteAcknowledgement of MassQuoteAcknowledgement
    | MultilegOrderCancelReplaceRequest of MultilegOrderCancelReplaceRequest
    | NetworkStatusRequest of NetworkStatusRequest
    | NetworkStatusResponse of NetworkStatusResponse
    | NewOrderCross of NewOrderCross
    | NewOrderList of NewOrderList
    | NewOrderMultileg of NewOrderMultileg
    | NewOrderSingle of NewOrderSingle
    | News of News
    | OrderCancelReject of OrderCancelReject
    | OrderCancelReplaceRequest of OrderCancelReplaceRequest
    | OrderCancelRequest of OrderCancelRequest
    | OrderMassCancelReport of OrderMassCancelReport
    | OrderMassCancelRequest of OrderMassCancelRequest
    | OrderMassStatusRequest of OrderMassStatusRequest
    | OrderStatusRequest of OrderStatusRequest
    | PositionMaintenanceReport of PositionMaintenanceReport
    | PositionMaintenanceRequest of PositionMaintenanceRequest
    | PositionReport of PositionReport
    | Quote of Quote
    | QuoteCancel of QuoteCancel
    | QuoteRequest of QuoteRequest
    | QuoteRequestReject of QuoteRequestReject
    | QuoteResponse of QuoteResponse
    | QuoteStatusReport of QuoteStatusReport
    | QuoteStatusRequest of QuoteStatusRequest
    | RFQRequest of RFQRequest
    | RegistrationInstructions of RegistrationInstructions
    | RegistrationInstructionsResponse of RegistrationInstructionsResponse
    | Reject of Reject
    | RequestForPositions of RequestForPositions
    | RequestForPositionsAck of RequestForPositionsAck
    | ResendRequest of ResendRequest
    | SecurityDefinition of SecurityDefinition
    | SecurityDefinitionRequest of SecurityDefinitionRequest
    | SecurityList of SecurityList
    | SecurityListRequest of SecurityListRequest
    | SecurityStatus of SecurityStatus
    | SecurityStatusRequest of SecurityStatusRequest
    | SecurityTypeRequest of SecurityTypeRequest
    | SecurityTypes of SecurityTypes
    | SequenceReset of SequenceReset
    | SettlementInstructionRequest of SettlementInstructionRequest
    | SettlementInstructions of SettlementInstructions
    | TestRequest of TestRequest
    | TradeCaptureReport of TradeCaptureReport
    | TradeCaptureReportAck of TradeCaptureReportAck
    | TradeCaptureReportRequest of TradeCaptureReportRequest
    | TradeCaptureReportRequestAck of TradeCaptureReportRequestAck
    | TradingSessionStatus of TradingSessionStatus
    | TradingSessionStatusRequest of TradingSessionStatusRequest
    | UserRequest of UserRequest
    | UserResponse of UserResponse



let WriteMessage dest nextFreeIdx msg =
    match msg with
    | Advertisement msg -> WriteAdvertisement dest nextFreeIdx msg
    | AllocationInstruction msg -> WriteAllocationInstruction dest nextFreeIdx msg
    | AllocationInstructionAck msg -> WriteAllocationInstructionAck dest nextFreeIdx msg
    | AllocationReport msg -> WriteAllocationReport dest nextFreeIdx msg
    | AllocationReportAck msg -> WriteAllocationReportAck dest nextFreeIdx msg
    | AssignmentReport msg -> WriteAssignmentReport dest nextFreeIdx msg
    | BidRequest msg -> WriteBidRequest dest nextFreeIdx msg
    | BidResponse msg -> WriteBidResponse dest nextFreeIdx msg
    | BusinessMessageReject msg -> WriteBusinessMessageReject dest nextFreeIdx msg
    | CollateralAssignment msg -> WriteCollateralAssignment dest nextFreeIdx msg
    | CollateralInquiry msg -> WriteCollateralInquiry dest nextFreeIdx msg
    | CollateralInquiryAck msg -> WriteCollateralInquiryAck dest nextFreeIdx msg
    | CollateralReport msg -> WriteCollateralReport dest nextFreeIdx msg
    | CollateralRequest msg -> WriteCollateralRequest dest nextFreeIdx msg
    | CollateralResponse msg -> WriteCollateralResponse dest nextFreeIdx msg
    | Confirmation msg -> WriteConfirmation dest nextFreeIdx msg
    | ConfirmationAck msg -> WriteConfirmationAck dest nextFreeIdx msg
    | ConfirmationRequest msg -> WriteConfirmationRequest dest nextFreeIdx msg
    | CrossOrderCancelReplaceRequest msg -> WriteCrossOrderCancelReplaceRequest dest nextFreeIdx msg
    | CrossOrderCancelRequest msg -> WriteCrossOrderCancelRequest dest nextFreeIdx msg
    | DerivativeSecurityList msg -> WriteDerivativeSecurityList dest nextFreeIdx msg
    | DerivativeSecurityListRequest msg -> WriteDerivativeSecurityListRequest dest nextFreeIdx msg
    | DontKnowTrade msg -> WriteDontKnowTrade dest nextFreeIdx msg
    | Email msg -> WriteEmail dest nextFreeIdx msg
    | ExecutionReport msg -> WriteExecutionReport dest nextFreeIdx msg
    | Heartbeat msg -> WriteHeartbeat dest nextFreeIdx msg
    | IndicationOfInterest msg -> WriteIndicationOfInterest dest nextFreeIdx msg
    | ListCancelRequest msg -> WriteListCancelRequest dest nextFreeIdx msg
    | ListExecute msg -> WriteListExecute dest nextFreeIdx msg
    | ListStatus msg -> WriteListStatus dest nextFreeIdx msg
    | ListStatusRequest msg -> WriteListStatusRequest dest nextFreeIdx msg
    | ListStrikePrice msg -> WriteListStrikePrice dest nextFreeIdx msg
    | Logon msg -> WriteLogon dest nextFreeIdx msg
    | Logout msg -> WriteLogout dest nextFreeIdx msg
    | MarketDataIncrementalRefresh msg -> WriteMarketDataIncrementalRefresh dest nextFreeIdx msg
    | MarketDataRequest msg -> WriteMarketDataRequest dest nextFreeIdx msg
    | MarketDataRequestReject msg -> WriteMarketDataRequestReject dest nextFreeIdx msg
    | MarketDataSnapshotFullRefresh msg -> WriteMarketDataSnapshotFullRefresh dest nextFreeIdx msg
    | MassQuote msg -> WriteMassQuote dest nextFreeIdx msg
    | MassQuoteAcknowledgement msg -> WriteMassQuoteAcknowledgement dest nextFreeIdx msg
    | MultilegOrderCancelReplaceRequest msg -> WriteMultilegOrderCancelReplaceRequest dest nextFreeIdx msg
    | NetworkStatusRequest msg -> WriteNetworkStatusRequest dest nextFreeIdx msg
    | NetworkStatusResponse msg -> WriteNetworkStatusResponse dest nextFreeIdx msg
    | NewOrderCross msg -> WriteNewOrderCross dest nextFreeIdx msg
    | NewOrderList msg -> WriteNewOrderList dest nextFreeIdx msg
    | NewOrderMultileg msg -> WriteNewOrderMultileg dest nextFreeIdx msg
    | NewOrderSingle msg -> WriteNewOrderSingle dest nextFreeIdx msg
    | News msg -> WriteNews dest nextFreeIdx msg
    | OrderCancelReject msg -> WriteOrderCancelReject dest nextFreeIdx msg
    | OrderCancelReplaceRequest msg -> WriteOrderCancelReplaceRequest dest nextFreeIdx msg
    | OrderCancelRequest msg -> WriteOrderCancelRequest dest nextFreeIdx msg
    | OrderMassCancelReport msg -> WriteOrderMassCancelReport dest nextFreeIdx msg
    | OrderMassCancelRequest msg -> WriteOrderMassCancelRequest dest nextFreeIdx msg
    | OrderMassStatusRequest msg -> WriteOrderMassStatusRequest dest nextFreeIdx msg
    | OrderStatusRequest msg -> WriteOrderStatusRequest dest nextFreeIdx msg
    | PositionMaintenanceReport msg -> WritePositionMaintenanceReport dest nextFreeIdx msg
    | PositionMaintenanceRequest msg -> WritePositionMaintenanceRequest dest nextFreeIdx msg
    | PositionReport msg -> WritePositionReport dest nextFreeIdx msg
    | Quote msg -> WriteQuote dest nextFreeIdx msg
    | QuoteCancel msg -> WriteQuoteCancel dest nextFreeIdx msg
    | QuoteRequest msg -> WriteQuoteRequest dest nextFreeIdx msg
    | QuoteRequestReject msg -> WriteQuoteRequestReject dest nextFreeIdx msg
    | QuoteResponse msg -> WriteQuoteResponse dest nextFreeIdx msg
    | QuoteStatusReport msg -> WriteQuoteStatusReport dest nextFreeIdx msg
    | QuoteStatusRequest msg -> WriteQuoteStatusRequest dest nextFreeIdx msg
    | RFQRequest msg -> WriteRFQRequest dest nextFreeIdx msg
    | RegistrationInstructions msg -> WriteRegistrationInstructions dest nextFreeIdx msg
    | RegistrationInstructionsResponse msg -> WriteRegistrationInstructionsResponse dest nextFreeIdx msg
    | Reject msg -> WriteReject dest nextFreeIdx msg
    | RequestForPositions msg -> WriteRequestForPositions dest nextFreeIdx msg
    | RequestForPositionsAck msg -> WriteRequestForPositionsAck dest nextFreeIdx msg
    | ResendRequest msg -> WriteResendRequest dest nextFreeIdx msg
    | SecurityDefinition msg -> WriteSecurityDefinition dest nextFreeIdx msg
    | SecurityDefinitionRequest msg -> WriteSecurityDefinitionRequest dest nextFreeIdx msg
    | SecurityList msg -> WriteSecurityList dest nextFreeIdx msg
    | SecurityListRequest msg -> WriteSecurityListRequest dest nextFreeIdx msg
    | SecurityStatus msg -> WriteSecurityStatus dest nextFreeIdx msg
    | SecurityStatusRequest msg -> WriteSecurityStatusRequest dest nextFreeIdx msg
    | SecurityTypeRequest msg -> WriteSecurityTypeRequest dest nextFreeIdx msg
    | SecurityTypes msg -> WriteSecurityTypes dest nextFreeIdx msg
    | SequenceReset msg -> WriteSequenceReset dest nextFreeIdx msg
    | SettlementInstructionRequest msg -> WriteSettlementInstructionRequest dest nextFreeIdx msg
    | SettlementInstructions msg -> WriteSettlementInstructions dest nextFreeIdx msg
    | TestRequest msg -> WriteTestRequest dest nextFreeIdx msg
    | TradeCaptureReport msg -> WriteTradeCaptureReport dest nextFreeIdx msg
    | TradeCaptureReportAck msg -> WriteTradeCaptureReportAck dest nextFreeIdx msg
    | TradeCaptureReportRequest msg -> WriteTradeCaptureReportRequest dest nextFreeIdx msg
    | TradeCaptureReportRequestAck msg -> WriteTradeCaptureReportRequestAck dest nextFreeIdx msg
    | TradingSessionStatus msg -> WriteTradingSessionStatus dest nextFreeIdx msg
    | TradingSessionStatusRequest msg -> WriteTradingSessionStatusRequest dest nextFreeIdx msg
    | UserRequest msg -> WriteUserRequest dest nextFreeIdx msg
    | UserResponse msg -> WriteUserResponse dest nextFreeIdx msg



let ReadMessage (selector:FIXMessage) pos bs =
    match selector with
    | Advertisement _ ->
        let pos, msg = ReadAdvertisement  pos bs
        pos, msg |> FIXMessage.Advertisement
    | AllocationInstruction _ ->
        let pos, msg = ReadAllocationInstruction  pos bs
        pos, msg |> FIXMessage.AllocationInstruction
    | AllocationInstructionAck _ ->
        let pos, msg = ReadAllocationInstructionAck  pos bs
        pos, msg |> FIXMessage.AllocationInstructionAck
    | AllocationReport _ ->
        let pos, msg = ReadAllocationReport  pos bs
        pos, msg |> FIXMessage.AllocationReport
    | AllocationReportAck _ ->
        let pos, msg = ReadAllocationReportAck  pos bs
        pos, msg |> FIXMessage.AllocationReportAck
    | AssignmentReport _ ->
        let pos, msg = ReadAssignmentReport  pos bs
        pos, msg |> FIXMessage.AssignmentReport
    | BidRequest _ ->
        let pos, msg = ReadBidRequest  pos bs
        pos, msg |> FIXMessage.BidRequest
    | BidResponse _ ->
        let pos, msg = ReadBidResponse  pos bs
        pos, msg |> FIXMessage.BidResponse
    | BusinessMessageReject _ ->
        let pos, msg = ReadBusinessMessageReject  pos bs
        pos, msg |> FIXMessage.BusinessMessageReject
    | CollateralAssignment _ ->
        let pos, msg = ReadCollateralAssignment  pos bs
        pos, msg |> FIXMessage.CollateralAssignment
    | CollateralInquiry _ ->
        let pos, msg = ReadCollateralInquiry  pos bs
        pos, msg |> FIXMessage.CollateralInquiry
    | CollateralInquiryAck _ ->
        let pos, msg = ReadCollateralInquiryAck  pos bs
        pos, msg |> FIXMessage.CollateralInquiryAck
    | CollateralReport _ ->
        let pos, msg = ReadCollateralReport  pos bs
        pos, msg |> FIXMessage.CollateralReport
    | CollateralRequest _ ->
        let pos, msg = ReadCollateralRequest  pos bs
        pos, msg |> FIXMessage.CollateralRequest
    | CollateralResponse _ ->
        let pos, msg = ReadCollateralResponse  pos bs
        pos, msg |> FIXMessage.CollateralResponse
    | Confirmation _ ->
        let pos, msg = ReadConfirmation  pos bs
        pos, msg |> FIXMessage.Confirmation
    | ConfirmationAck _ ->
        let pos, msg = ReadConfirmationAck  pos bs
        pos, msg |> FIXMessage.ConfirmationAck
    | ConfirmationRequest _ ->
        let pos, msg = ReadConfirmationRequest  pos bs
        pos, msg |> FIXMessage.ConfirmationRequest
    | CrossOrderCancelReplaceRequest _ ->
        let pos, msg = ReadCrossOrderCancelReplaceRequest  pos bs
        pos, msg |> FIXMessage.CrossOrderCancelReplaceRequest
    | CrossOrderCancelRequest _ ->
        let pos, msg = ReadCrossOrderCancelRequest  pos bs
        pos, msg |> FIXMessage.CrossOrderCancelRequest
    | DerivativeSecurityList _ ->
        let pos, msg = ReadDerivativeSecurityList  pos bs
        pos, msg |> FIXMessage.DerivativeSecurityList
    | DerivativeSecurityListRequest _ ->
        let pos, msg = ReadDerivativeSecurityListRequest  pos bs
        pos, msg |> FIXMessage.DerivativeSecurityListRequest
    | DontKnowTrade _ ->
        let pos, msg = ReadDontKnowTrade  pos bs
        pos, msg |> FIXMessage.DontKnowTrade
    | Email _ ->
        let pos, msg = ReadEmail  pos bs
        pos, msg |> FIXMessage.Email
    | ExecutionReport _ ->
        let pos, msg = ReadExecutionReport  pos bs
        pos, msg |> FIXMessage.ExecutionReport
    | Heartbeat _ ->
        let pos, msg = ReadHeartbeat  pos bs
        pos, msg |> FIXMessage.Heartbeat
    | IndicationOfInterest _ ->
        let pos, msg = ReadIndicationOfInterest  pos bs
        pos, msg |> FIXMessage.IndicationOfInterest
    | ListCancelRequest _ ->
        let pos, msg = ReadListCancelRequest  pos bs
        pos, msg |> FIXMessage.ListCancelRequest
    | ListExecute _ ->
        let pos, msg = ReadListExecute  pos bs
        pos, msg |> FIXMessage.ListExecute
    | ListStatus _ ->
        let pos, msg = ReadListStatus  pos bs
        pos, msg |> FIXMessage.ListStatus
    | ListStatusRequest _ ->
        let pos, msg = ReadListStatusRequest  pos bs
        pos, msg |> FIXMessage.ListStatusRequest
    | ListStrikePrice _ ->
        let pos, msg = ReadListStrikePrice  pos bs
        pos, msg |> FIXMessage.ListStrikePrice
    | Logon _ ->
        let pos, msg = ReadLogon  pos bs
        pos, msg |> FIXMessage.Logon
    | Logout _ ->
        let pos, msg = ReadLogout  pos bs
        pos, msg |> FIXMessage.Logout
    | MarketDataIncrementalRefresh _ ->
        let pos, msg = ReadMarketDataIncrementalRefresh  pos bs
        pos, msg |> FIXMessage.MarketDataIncrementalRefresh
    | MarketDataRequest _ ->
        let pos, msg = ReadMarketDataRequest  pos bs
        pos, msg |> FIXMessage.MarketDataRequest
    | MarketDataRequestReject _ ->
        let pos, msg = ReadMarketDataRequestReject  pos bs
        pos, msg |> FIXMessage.MarketDataRequestReject
    | MarketDataSnapshotFullRefresh _ ->
        let pos, msg = ReadMarketDataSnapshotFullRefresh  pos bs
        pos, msg |> FIXMessage.MarketDataSnapshotFullRefresh
    | MassQuote _ ->
        let pos, msg = ReadMassQuote  pos bs
        pos, msg |> FIXMessage.MassQuote
    | MassQuoteAcknowledgement _ ->
        let pos, msg = ReadMassQuoteAcknowledgement  pos bs
        pos, msg |> FIXMessage.MassQuoteAcknowledgement
    | MultilegOrderCancelReplaceRequest _ ->
        let pos, msg = ReadMultilegOrderCancelReplaceRequest  pos bs
        pos, msg |> FIXMessage.MultilegOrderCancelReplaceRequest
    | NetworkStatusRequest _ ->
        let pos, msg = ReadNetworkStatusRequest  pos bs
        pos, msg |> FIXMessage.NetworkStatusRequest
    | NetworkStatusResponse _ ->
        let pos, msg = ReadNetworkStatusResponse  pos bs
        pos, msg |> FIXMessage.NetworkStatusResponse
    | NewOrderCross _ ->
        let pos, msg = ReadNewOrderCross  pos bs
        pos, msg |> FIXMessage.NewOrderCross
    | NewOrderList _ ->
        let pos, msg = ReadNewOrderList  pos bs
        pos, msg |> FIXMessage.NewOrderList
    | NewOrderMultileg _ ->
        let pos, msg = ReadNewOrderMultileg  pos bs
        pos, msg |> FIXMessage.NewOrderMultileg
    | NewOrderSingle _ ->
        let pos, msg = ReadNewOrderSingle  pos bs
        pos, msg |> FIXMessage.NewOrderSingle
    | News _ ->
        let pos, msg = ReadNews  pos bs
        pos, msg |> FIXMessage.News
    | OrderCancelReject _ ->
        let pos, msg = ReadOrderCancelReject  pos bs
        pos, msg |> FIXMessage.OrderCancelReject
    | OrderCancelReplaceRequest _ ->
        let pos, msg = ReadOrderCancelReplaceRequest  pos bs
        pos, msg |> FIXMessage.OrderCancelReplaceRequest
    | OrderCancelRequest _ ->
        let pos, msg = ReadOrderCancelRequest  pos bs
        pos, msg |> FIXMessage.OrderCancelRequest
    | OrderMassCancelReport _ ->
        let pos, msg = ReadOrderMassCancelReport  pos bs
        pos, msg |> FIXMessage.OrderMassCancelReport
    | OrderMassCancelRequest _ ->
        let pos, msg = ReadOrderMassCancelRequest  pos bs
        pos, msg |> FIXMessage.OrderMassCancelRequest
    | OrderMassStatusRequest _ ->
        let pos, msg = ReadOrderMassStatusRequest  pos bs
        pos, msg |> FIXMessage.OrderMassStatusRequest
    | OrderStatusRequest _ ->
        let pos, msg = ReadOrderStatusRequest  pos bs
        pos, msg |> FIXMessage.OrderStatusRequest
    | PositionMaintenanceReport _ ->
        let pos, msg = ReadPositionMaintenanceReport  pos bs
        pos, msg |> FIXMessage.PositionMaintenanceReport
    | PositionMaintenanceRequest _ ->
        let pos, msg = ReadPositionMaintenanceRequest  pos bs
        pos, msg |> FIXMessage.PositionMaintenanceRequest
    | PositionReport _ ->
        let pos, msg = ReadPositionReport  pos bs
        pos, msg |> FIXMessage.PositionReport
    | Quote _ ->
        let pos, msg = ReadQuote  pos bs
        pos, msg |> FIXMessage.Quote
    | QuoteCancel _ ->
        let pos, msg = ReadQuoteCancel  pos bs
        pos, msg |> FIXMessage.QuoteCancel
    | QuoteRequest _ ->
        let pos, msg = ReadQuoteRequest  pos bs
        pos, msg |> FIXMessage.QuoteRequest
    | QuoteRequestReject _ ->
        let pos, msg = ReadQuoteRequestReject  pos bs
        pos, msg |> FIXMessage.QuoteRequestReject
    | QuoteResponse _ ->
        let pos, msg = ReadQuoteResponse  pos bs
        pos, msg |> FIXMessage.QuoteResponse
    | QuoteStatusReport _ ->
        let pos, msg = ReadQuoteStatusReport  pos bs
        pos, msg |> FIXMessage.QuoteStatusReport
    | QuoteStatusRequest _ ->
        let pos, msg = ReadQuoteStatusRequest  pos bs
        pos, msg |> FIXMessage.QuoteStatusRequest
    | RFQRequest _ ->
        let pos, msg = ReadRFQRequest  pos bs
        pos, msg |> FIXMessage.RFQRequest
    | RegistrationInstructions _ ->
        let pos, msg = ReadRegistrationInstructions  pos bs
        pos, msg |> FIXMessage.RegistrationInstructions
    | RegistrationInstructionsResponse _ ->
        let pos, msg = ReadRegistrationInstructionsResponse  pos bs
        pos, msg |> FIXMessage.RegistrationInstructionsResponse
    | Reject _ ->
        let pos, msg = ReadReject  pos bs
        pos, msg |> FIXMessage.Reject
    | RequestForPositions _ ->
        let pos, msg = ReadRequestForPositions  pos bs
        pos, msg |> FIXMessage.RequestForPositions
    | RequestForPositionsAck _ ->
        let pos, msg = ReadRequestForPositionsAck  pos bs
        pos, msg |> FIXMessage.RequestForPositionsAck
    | ResendRequest _ ->
        let pos, msg = ReadResendRequest  pos bs
        pos, msg |> FIXMessage.ResendRequest
    | SecurityDefinition _ ->
        let pos, msg = ReadSecurityDefinition  pos bs
        pos, msg |> FIXMessage.SecurityDefinition
    | SecurityDefinitionRequest _ ->
        let pos, msg = ReadSecurityDefinitionRequest  pos bs
        pos, msg |> FIXMessage.SecurityDefinitionRequest
    | SecurityList _ ->
        let pos, msg = ReadSecurityList  pos bs
        pos, msg |> FIXMessage.SecurityList
    | SecurityListRequest _ ->
        let pos, msg = ReadSecurityListRequest  pos bs
        pos, msg |> FIXMessage.SecurityListRequest
    | SecurityStatus _ ->
        let pos, msg = ReadSecurityStatus  pos bs
        pos, msg |> FIXMessage.SecurityStatus
    | SecurityStatusRequest _ ->
        let pos, msg = ReadSecurityStatusRequest  pos bs
        pos, msg |> FIXMessage.SecurityStatusRequest
    | SecurityTypeRequest _ ->
        let pos, msg = ReadSecurityTypeRequest  pos bs
        pos, msg |> FIXMessage.SecurityTypeRequest
    | SecurityTypes _ ->
        let pos, msg = ReadSecurityTypes  pos bs
        pos, msg |> FIXMessage.SecurityTypes
    | SequenceReset _ ->
        let pos, msg = ReadSequenceReset  pos bs
        pos, msg |> FIXMessage.SequenceReset
    | SettlementInstructionRequest _ ->
        let pos, msg = ReadSettlementInstructionRequest  pos bs
        pos, msg |> FIXMessage.SettlementInstructionRequest
    | SettlementInstructions _ ->
        let pos, msg = ReadSettlementInstructions  pos bs
        pos, msg |> FIXMessage.SettlementInstructions
    | TestRequest _ ->
        let pos, msg = ReadTestRequest  pos bs
        pos, msg |> FIXMessage.TestRequest
    | TradeCaptureReport _ ->
        let pos, msg = ReadTradeCaptureReport  pos bs
        pos, msg |> FIXMessage.TradeCaptureReport
    | TradeCaptureReportAck _ ->
        let pos, msg = ReadTradeCaptureReportAck  pos bs
        pos, msg |> FIXMessage.TradeCaptureReportAck
    | TradeCaptureReportRequest _ ->
        let pos, msg = ReadTradeCaptureReportRequest  pos bs
        pos, msg |> FIXMessage.TradeCaptureReportRequest
    | TradeCaptureReportRequestAck _ ->
        let pos, msg = ReadTradeCaptureReportRequestAck  pos bs
        pos, msg |> FIXMessage.TradeCaptureReportRequestAck
    | TradingSessionStatus _ ->
        let pos, msg = ReadTradingSessionStatus  pos bs
        pos, msg |> FIXMessage.TradingSessionStatus
    | TradingSessionStatusRequest _ ->
        let pos, msg = ReadTradingSessionStatusRequest  pos bs
        pos, msg |> FIXMessage.TradingSessionStatusRequest
    | UserRequest _ ->
        let pos, msg = ReadUserRequest  pos bs
        pos, msg |> FIXMessage.UserRequest
    | UserResponse _ ->
        let pos, msg = ReadUserResponse  pos bs
        pos, msg |> FIXMessage.UserResponse



let ReadMessageDU (tag:byte []) pos bs =
    match tag with
    | "0"B   ->
        let pos, msg = ReadHeartbeat pos bs
        pos, msg |> FIXMessage.Heartbeat
    | "A"B   ->
        let pos, msg = ReadLogon pos bs
        pos, msg |> FIXMessage.Logon
    | "1"B   ->
        let pos, msg = ReadTestRequest pos bs
        pos, msg |> FIXMessage.TestRequest
    | "2"B   ->
        let pos, msg = ReadResendRequest pos bs
        pos, msg |> FIXMessage.ResendRequest
    | "3"B   ->
        let pos, msg = ReadReject pos bs
        pos, msg |> FIXMessage.Reject
    | "4"B   ->
        let pos, msg = ReadSequenceReset pos bs
        pos, msg |> FIXMessage.SequenceReset
    | "5"B   ->
        let pos, msg = ReadLogout pos bs
        pos, msg |> FIXMessage.Logout
    | "j"B   ->
        let pos, msg = ReadBusinessMessageReject pos bs
        pos, msg |> FIXMessage.BusinessMessageReject
    | "BE"B   ->
        let pos, msg = ReadUserRequest pos bs
        pos, msg |> FIXMessage.UserRequest
    | "BF"B   ->
        let pos, msg = ReadUserResponse pos bs
        pos, msg |> FIXMessage.UserResponse
    | "7"B   ->
        let pos, msg = ReadAdvertisement pos bs
        pos, msg |> FIXMessage.Advertisement
    | "6"B   ->
        let pos, msg = ReadIndicationOfInterest pos bs
        pos, msg |> FIXMessage.IndicationOfInterest
    | "B"B   ->
        let pos, msg = ReadNews pos bs
        pos, msg |> FIXMessage.News
    | "C"B   ->
        let pos, msg = ReadEmail pos bs
        pos, msg |> FIXMessage.Email
    | "R"B   ->
        let pos, msg = ReadQuoteRequest pos bs
        pos, msg |> FIXMessage.QuoteRequest
    | "AJ"B   ->
        let pos, msg = ReadQuoteResponse pos bs
        pos, msg |> FIXMessage.QuoteResponse
    | "AG"B   ->
        let pos, msg = ReadQuoteRequestReject pos bs
        pos, msg |> FIXMessage.QuoteRequestReject
    | "AH"B   ->
        let pos, msg = ReadRFQRequest pos bs
        pos, msg |> FIXMessage.RFQRequest
    | "S"B   ->
        let pos, msg = ReadQuote pos bs
        pos, msg |> FIXMessage.Quote
    | "Z"B   ->
        let pos, msg = ReadQuoteCancel pos bs
        pos, msg |> FIXMessage.QuoteCancel
    | "a"B   ->
        let pos, msg = ReadQuoteStatusRequest pos bs
        pos, msg |> FIXMessage.QuoteStatusRequest
    | "AI"B   ->
        let pos, msg = ReadQuoteStatusReport pos bs
        pos, msg |> FIXMessage.QuoteStatusReport
    | "i"B   ->
        let pos, msg = ReadMassQuote pos bs
        pos, msg |> FIXMessage.MassQuote
    | "b"B   ->
        let pos, msg = ReadMassQuoteAcknowledgement pos bs
        pos, msg |> FIXMessage.MassQuoteAcknowledgement
    | "V"B   ->
        let pos, msg = ReadMarketDataRequest pos bs
        pos, msg |> FIXMessage.MarketDataRequest
    | "W"B   ->
        let pos, msg = ReadMarketDataSnapshotFullRefresh pos bs
        pos, msg |> FIXMessage.MarketDataSnapshotFullRefresh
    | "X"B   ->
        let pos, msg = ReadMarketDataIncrementalRefresh pos bs
        pos, msg |> FIXMessage.MarketDataIncrementalRefresh
    | "Y"B   ->
        let pos, msg = ReadMarketDataRequestReject pos bs
        pos, msg |> FIXMessage.MarketDataRequestReject
    | "c"B   ->
        let pos, msg = ReadSecurityDefinitionRequest pos bs
        pos, msg |> FIXMessage.SecurityDefinitionRequest
    | "d"B   ->
        let pos, msg = ReadSecurityDefinition pos bs
        pos, msg |> FIXMessage.SecurityDefinition
    | "v"B   ->
        let pos, msg = ReadSecurityTypeRequest pos bs
        pos, msg |> FIXMessage.SecurityTypeRequest
    | "w"B   ->
        let pos, msg = ReadSecurityTypes pos bs
        pos, msg |> FIXMessage.SecurityTypes
    | "x"B   ->
        let pos, msg = ReadSecurityListRequest pos bs
        pos, msg |> FIXMessage.SecurityListRequest
    | "y"B   ->
        let pos, msg = ReadSecurityList pos bs
        pos, msg |> FIXMessage.SecurityList
    | "z"B   ->
        let pos, msg = ReadDerivativeSecurityListRequest pos bs
        pos, msg |> FIXMessage.DerivativeSecurityListRequest
    | "AA"B   ->
        let pos, msg = ReadDerivativeSecurityList pos bs
        pos, msg |> FIXMessage.DerivativeSecurityList
    | "e"B   ->
        let pos, msg = ReadSecurityStatusRequest pos bs
        pos, msg |> FIXMessage.SecurityStatusRequest
    | "f"B   ->
        let pos, msg = ReadSecurityStatus pos bs
        pos, msg |> FIXMessage.SecurityStatus
    | "g"B   ->
        let pos, msg = ReadTradingSessionStatusRequest pos bs
        pos, msg |> FIXMessage.TradingSessionStatusRequest
    | "h"B   ->
        let pos, msg = ReadTradingSessionStatus pos bs
        pos, msg |> FIXMessage.TradingSessionStatus
    | "D"B   ->
        let pos, msg = ReadNewOrderSingle pos bs
        pos, msg |> FIXMessage.NewOrderSingle
    | "8"B   ->
        let pos, msg = ReadExecutionReport pos bs
        pos, msg |> FIXMessage.ExecutionReport
    | "Q"B   ->
        let pos, msg = ReadDontKnowTrade pos bs
        pos, msg |> FIXMessage.DontKnowTrade
    | "G"B   ->
        let pos, msg = ReadOrderCancelReplaceRequest pos bs
        pos, msg |> FIXMessage.OrderCancelReplaceRequest
    | "F"B   ->
        let pos, msg = ReadOrderCancelRequest pos bs
        pos, msg |> FIXMessage.OrderCancelRequest
    | "9"B   ->
        let pos, msg = ReadOrderCancelReject pos bs
        pos, msg |> FIXMessage.OrderCancelReject
    | "H"B   ->
        let pos, msg = ReadOrderStatusRequest pos bs
        pos, msg |> FIXMessage.OrderStatusRequest
    | "q"B   ->
        let pos, msg = ReadOrderMassCancelRequest pos bs
        pos, msg |> FIXMessage.OrderMassCancelRequest
    | "r"B   ->
        let pos, msg = ReadOrderMassCancelReport pos bs
        pos, msg |> FIXMessage.OrderMassCancelReport
    | "AF"B   ->
        let pos, msg = ReadOrderMassStatusRequest pos bs
        pos, msg |> FIXMessage.OrderMassStatusRequest
    | "s"B   ->
        let pos, msg = ReadNewOrderCross pos bs
        pos, msg |> FIXMessage.NewOrderCross
    | "t"B   ->
        let pos, msg = ReadCrossOrderCancelReplaceRequest pos bs
        pos, msg |> FIXMessage.CrossOrderCancelReplaceRequest
    | "u"B   ->
        let pos, msg = ReadCrossOrderCancelRequest pos bs
        pos, msg |> FIXMessage.CrossOrderCancelRequest
    | "AB"B   ->
        let pos, msg = ReadNewOrderMultileg pos bs
        pos, msg |> FIXMessage.NewOrderMultileg
    | "AC"B   ->
        let pos, msg = ReadMultilegOrderCancelReplaceRequest pos bs
        pos, msg |> FIXMessage.MultilegOrderCancelReplaceRequest
    | "k"B   ->
        let pos, msg = ReadBidRequest pos bs
        pos, msg |> FIXMessage.BidRequest
    | "l"B   ->
        let pos, msg = ReadBidResponse pos bs
        pos, msg |> FIXMessage.BidResponse
    | "E"B   ->
        let pos, msg = ReadNewOrderList pos bs
        pos, msg |> FIXMessage.NewOrderList
    | "m"B   ->
        let pos, msg = ReadListStrikePrice pos bs
        pos, msg |> FIXMessage.ListStrikePrice
    | "N"B   ->
        let pos, msg = ReadListStatus pos bs
        pos, msg |> FIXMessage.ListStatus
    | "L"B   ->
        let pos, msg = ReadListExecute pos bs
        pos, msg |> FIXMessage.ListExecute
    | "K"B   ->
        let pos, msg = ReadListCancelRequest pos bs
        pos, msg |> FIXMessage.ListCancelRequest
    | "M"B   ->
        let pos, msg = ReadListStatusRequest pos bs
        pos, msg |> FIXMessage.ListStatusRequest
    | "J"B   ->
        let pos, msg = ReadAllocationInstruction pos bs
        pos, msg |> FIXMessage.AllocationInstruction
    | "P"B   ->
        let pos, msg = ReadAllocationInstructionAck pos bs
        pos, msg |> FIXMessage.AllocationInstructionAck
    | "AS"B   ->
        let pos, msg = ReadAllocationReport pos bs
        pos, msg |> FIXMessage.AllocationReport
    | "AT"B   ->
        let pos, msg = ReadAllocationReportAck pos bs
        pos, msg |> FIXMessage.AllocationReportAck
    | "AK"B   ->
        let pos, msg = ReadConfirmation pos bs
        pos, msg |> FIXMessage.Confirmation
    | "AU"B   ->
        let pos, msg = ReadConfirmationAck pos bs
        pos, msg |> FIXMessage.ConfirmationAck
    | "BH"B   ->
        let pos, msg = ReadConfirmationRequest pos bs
        pos, msg |> FIXMessage.ConfirmationRequest
    | "T"B   ->
        let pos, msg = ReadSettlementInstructions pos bs
        pos, msg |> FIXMessage.SettlementInstructions
    | "AV"B   ->
        let pos, msg = ReadSettlementInstructionRequest pos bs
        pos, msg |> FIXMessage.SettlementInstructionRequest
    | "AD"B   ->
        let pos, msg = ReadTradeCaptureReportRequest pos bs
        pos, msg |> FIXMessage.TradeCaptureReportRequest
    | "AQ"B   ->
        let pos, msg = ReadTradeCaptureReportRequestAck pos bs
        pos, msg |> FIXMessage.TradeCaptureReportRequestAck
    | "AE"B   ->
        let pos, msg = ReadTradeCaptureReport pos bs
        pos, msg |> FIXMessage.TradeCaptureReport
    | "AR"B   ->
        let pos, msg = ReadTradeCaptureReportAck pos bs
        pos, msg |> FIXMessage.TradeCaptureReportAck
    | "o"B   ->
        let pos, msg = ReadRegistrationInstructions pos bs
        pos, msg |> FIXMessage.RegistrationInstructions
    | "p"B   ->
        let pos, msg = ReadRegistrationInstructionsResponse pos bs
        pos, msg |> FIXMessage.RegistrationInstructionsResponse
    | "AL"B   ->
        let pos, msg = ReadPositionMaintenanceRequest pos bs
        pos, msg |> FIXMessage.PositionMaintenanceRequest
    | "AM"B   ->
        let pos, msg = ReadPositionMaintenanceReport pos bs
        pos, msg |> FIXMessage.PositionMaintenanceReport
    | "AN"B   ->
        let pos, msg = ReadRequestForPositions pos bs
        pos, msg |> FIXMessage.RequestForPositions
    | "AO"B   ->
        let pos, msg = ReadRequestForPositionsAck pos bs
        pos, msg |> FIXMessage.RequestForPositionsAck
    | "AP"B   ->
        let pos, msg = ReadPositionReport pos bs
        pos, msg |> FIXMessage.PositionReport
    | "AW"B   ->
        let pos, msg = ReadAssignmentReport pos bs
        pos, msg |> FIXMessage.AssignmentReport
    | "AX"B   ->
        let pos, msg = ReadCollateralRequest pos bs
        pos, msg |> FIXMessage.CollateralRequest
    | "AY"B   ->
        let pos, msg = ReadCollateralAssignment pos bs
        pos, msg |> FIXMessage.CollateralAssignment
    | "AZ"B   ->
        let pos, msg = ReadCollateralResponse pos bs
        pos, msg |> FIXMessage.CollateralResponse
    | "BA"B   ->
        let pos, msg = ReadCollateralReport pos bs
        pos, msg |> FIXMessage.CollateralReport
    | "BB"B   ->
        let pos, msg = ReadCollateralInquiry pos bs
        pos, msg |> FIXMessage.CollateralInquiry
    | "BC"B   ->
        let pos, msg = ReadNetworkStatusRequest pos bs
        pos, msg |> FIXMessage.NetworkStatusRequest
    | "BD"B   ->
        let pos, msg = ReadNetworkStatusResponse pos bs
        pos, msg |> FIXMessage.NetworkStatusResponse
    | "BG"B   ->
        let pos, msg = ReadCollateralInquiryAck pos bs
        pos, msg |> FIXMessage.CollateralInquiryAck
    | invalidTag   ->
        let ss = sprintf "received unknown message type tag: %A" invalidTag
        failwith ss
